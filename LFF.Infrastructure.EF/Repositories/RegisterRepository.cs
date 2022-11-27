using LFF.Core.DTOs.Base;
using LFF.Core.Entities;
using LFF.Core.Repositories;
using LFF.Infrastructure.EF.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LFF.Infrastructure.EF.Repositories
{
    public class RegisterRepository : RepositoryBase<Register>, IRegisterRepository
    {
        private readonly IDbContextFactory<AppDbContext> dbFactory;

        public RegisterRepository(IDbContextFactory<AppDbContext> dbFactory)
          : base(dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public async Task<Register> GetRegisterByIdAsync(Guid id)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseGetAsync(u => u.Id == id);
            }
        }

        public async Task<bool> CheckRegisterExistedByIdAsync(Guid id)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseAnyAsync(u => u.Id == id);
            }
        }

        public async Task<bool> CheckRegisterExistedByStudentAndClassId(Guid studentId, Guid classId)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                return await dbs.Registers.Where(u => u.DeletedAt == null).AnyAsync(u => u.StudentId == studentId && u.ClassId == classId);
            }
        }

        public override async Task<IEnumerable<Register>> ListByQueriesAsync(IEnumerable<SearchQueryItem> queries)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                var query = dbs.Set<Register>().Select(u => u).Where(u => u.DeletedAt == null);

                foreach (var q in queries)
                {
                    var tokens = q.Name.ToLower().Split(".");
                    if (tokens.Length < 2 || q.Values.Count == 0)
                        throw new ArgumentException($"Tham số không hợp lệ '{q.Name}'");
                    if (tokens[0] == "registrationdate")
                    {
                        if (tokens[1] == "min")
                            query = query.Where(u => u.RegistrationDate >= DateTime.Parse(q.Values[0]));
                        else if (tokens[1] == "max")
                            query = query.Where(u => u.RegistrationDate <= DateTime.Parse(q.Values[0]));
                        else if (tokens[1] == "equal")
                            query = query.Where(u => u.RegistrationDate == DateTime.Parse(q.Values[0]));
                        else throw new ArgumentException($"Unknown query {q.Name}");
                    }
                    else throw new ArgumentException($"Unknown query {q.Name}");
                }

                var students = from user in dbs.Users
                               where user.DeletedAt == null && user.Role == UserRoles.Student
                               select user;

                var classrooms = from classroom in dbs.Classrooms
                                 where classroom.DeletedAt == null
                                 select classroom;

                var linq = from register in query
                           join student in students on register.StudentId equals student.Id
                           join classroom in classrooms on register.ClassId equals classroom.Id
                           select new
                           {
                               register = register,
                               student = student,
                               classroom = classroom
                           };

                var result = (await linq.ToListAsync())
                    .Select(u =>
                    {
                        u.register.Student = u.student;
                        u.register.Class = u.classroom;
                        return u.register;
                    });

                return result;
            }
        }
    }
}
