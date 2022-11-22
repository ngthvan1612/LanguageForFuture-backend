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
    public class StudentTestRepository : RepositoryBase<StudentTest>, IStudentTestRepository
    {
        private readonly IDbContextFactory<AppDbContext> dbFactory;

        public StudentTestRepository(IDbContextFactory<AppDbContext> dbFactory)
          : base(dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public override Task<StudentTest> CreateAsync(StudentTest entity)
        {
            entity.SubmittedOn = null;
            return base.CreateAsync(entity);
        }

        public async Task<StudentTest> GetStudentTestByIdAsync(Guid id)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseGetAsync(u => u.Id == id);
            }
        }

        public async Task<bool> CheckStudentTestExistedByIdAsync(Guid id)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseAnyAsync(u => u.Id == id);
            }
        }

        public override async Task<IEnumerable<StudentTest>> ListByQueriesAsync(IEnumerable<SearchQueryItem> queries)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                var query = dbs.Set<StudentTest>().Select(u => u).Where(u => u.DeletedAt == null);
                foreach (var q in queries)
                {
                    var tokens = q.Name.ToLower().Split(".");
                    if (tokens.Length < 2 || q.Values.Count == 0)
                        throw new ArgumentException($"Tham số không hợp lệ '{q.Name}'");
                    if (tokens[0] == "startdate")
                    {
                        if (tokens[1] == "min")
                            query = query.Where(u => u.StartDate >= DateTime.Parse(q.Values[0]));
                        else if (tokens[1] == "max")
                            query = query.Where(u => u.StartDate <= DateTime.Parse(q.Values[0]));
                        else if (tokens[1] == "equal")
                            query = query.Where(u => u.StartDate == DateTime.Parse(q.Values[0]));
                        else throw new ArgumentException($"Unknown query {q.Name}");
                    }
                    else throw new ArgumentException($"Unknown query {q.Name}");
                }

                var students = dbs.Users.Where(u => u.DeletedAt == null && u.Role == UserRoles.Student);
                var tests = dbs.Tests.Where(u => u.DeletedAt == null);

                var linq = from studentTest in query
                           join student in students on studentTest.StudentId equals student.Id
                           join test in tests on studentTest.TestId equals test.Id
                           select new
                           {
                               studentTest = studentTest,
                               student = student,
                               test = test
                           };

                var result = (await linq.ToListAsync())
                    .Select(u =>
                    {
                        u.studentTest.Student = u.student;
                        u.studentTest.Test = u.test;
                        return u.studentTest;
                    });

                return result;
            }
        }
    }
}
