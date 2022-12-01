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
                var query = dbs.GetFixedStudentTests();

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
                    else if (tokens[0] == "student_id")
                    {
                        if (tokens[1] == "equal")
                        {
                            Guid studentId = Guid.Parse(q.Values[0]);
                            query = query.Where(u => u.StudentId == studentId);
                        }
                        else throw new ArgumentException($"Unknown query {q.Name}");
                    }
                    else if (tokens[0] == "test_id")
                    {
                        if (tokens[1] == "equal")
                        {
                            Guid testId = Guid.Parse(q.Values[0]);
                            query = query.Where(u => u.TestId == testId);
                        }
                        else throw new ArgumentException($"Unknown query {q.Name}");
                    }
                    else if (tokens[0] == "is_running")
                    {
                        if (tokens[1] == "equal")
                        {
                            if (q.Values[0] == "true")
                            {
                                query = from studentTest in query
                                        join test in dbs.GetFixedTests() on studentTest.TestId equals test.Id
                                        where studentTest.StartDate <= DateTime.Now && DateTime.Now <= studentTest.StartDate.Value.AddMinutes(test.Time ?? 0)
                                        select studentTest;
                            }
                            else if (q.Values[0] == "false")
                            {
                                //Nothing
                            }
                            else throw new ArgumentException($"Unknown value {q.Values[0]}");
                        }
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

        public async Task AutoChangeStateSubmission()
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                var needUpdates = from studentTest in dbs.GetFixedStudentTests()
                                  join test in dbs.GetFixedTests() on studentTest.TestId equals test.Id
                                  where studentTest.StartDate.Value.AddMinutes(test.Time.Value) < DateTime.Now
                                  where studentTest.SubmittedOn == null
                                  select studentTest;

                await needUpdates.ForEachAsync(u => u.SubmittedOn = DateTime.Now);

                //foreach (var u in needUpdates)
                //    Console.Write(u.Id);

                await dbs.SaveChangesAsync();
            }
        }

        public async Task SubmitTestAsync(Guid id)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                var studentTest = dbs.StudentTests.FirstOrDefault(u => u.Id == id);
                if (studentTest != null)
                    studentTest.SubmittedOn = DateTime.Now;
                await dbs.SaveChangesAsync();
            }
        }
    }
}
