using LFF.Core.DTOs.Base;
using LFF.Core.Entities;
using LFF.Core.Repositories;
using LFF.Core.Utils.Questions;
using LFF.Infrastructure.EF.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LFF.Infrastructure.EF.Repositories
{
    public class StudentTestResultRepository : RepositoryBase<StudentTestResult>, IStudentTestResultRepository
    {
        private readonly IDbContextFactory<AppDbContext> dbFactory;

        public StudentTestResultRepository(IDbContextFactory<AppDbContext> dbFactory)
          : base(dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public async Task<StudentTestResult> GetStudentTestResultByIdAsync(Guid id)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseGetAsync(u => u.Id == id);
            }
        }

        public async Task<bool> CheckStudentTestResultExistedByIdAsync(Guid id)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseAnyAsync(u => u.Id == id);
            }
        }

        public override async Task<IEnumerable<StudentTestResult>> ListByQueriesAsync(IEnumerable<SearchQueryItem> queries)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                var query = dbs.Set<StudentTestResult>().Select(u => u).Where(u => u.DeletedAt == null);
                foreach (var q in queries)
                {
                    var tokens = q.Name.ToLower().Split(".");
                    if (tokens.Length < 2 || q.Values.Count == 0)
                        throw new ArgumentException($"Tham số không hợp lệ '{q.Name}'");
                    if (tokens[0] == "result")
                    {
                        if (tokens[1] == "startswith")
                            query = query.Where(u => u.Result.StartsWith(q.Values[0]));
                        else if (tokens[1] == "endswith")
                            query = query.Where(u => u.Result.EndsWith(q.Values[0]));
                        else if (tokens[1] == "contains")
                            query = query.Where(u => u.Result.Contains(q.Values[0]));
                        else if (tokens[1] == "equal")
                            query = query.Where(u => u.Result == q.Values[0]);
                        else throw new ArgumentException($"Unknown query {q.Name}");
                    }
                    else throw new ArgumentException($"Unknown query {q.Name}");
                }

                var questions = dbs.Questions.Where(u => u.DeletedAt == null);
                var studentTests = dbs.StudentTests.Where(u => u.DeletedAt == null);

                var linq = from result in query
                           join question in questions on result.QuestionId equals question.Id
                           join studentTest in studentTests on result.StudentTestId equals studentTest.Id
                           select new
                           {
                               result = result,
                               question = question,
                               studentTest = studentTest
                           };

                var res = (await linq.ToListAsync())
                    .Select(u =>
                    {
                        u.result.StudentTest = u.studentTest;
                        u.result.Question = u.question;
                        return u.result;
                    });

                return res;
            }
        }

        //Chặn phương thức Create mặc định
        public override Task<StudentTestResult> CreateAsync(StudentTestResult entity)
        {
            throw new NotSupportedException();
        }

        //Chặn phương thức Update mặc định
        public override Task<StudentTestResult> UpdateAsync(StudentTestResult entity)
        {
            throw new NotSupportedException();
        }

        public async Task<StudentTestResult> CreateOrUpdateResult(StudentTestResult studentTestResult)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                var temp = await dbs.StudentTestResults
                    .FirstOrDefaultAsync(u =>
                        u.StudentTestId == studentTestResult.StudentTestId &&
                        u.QuestionId == studentTestResult.QuestionId);
                if (temp != null)
                {
                    temp.Result = studentTestResult.Result;
                    await dbs.SaveChangesAsync();
                    return temp;
                }
                else
                {
                    studentTestResult.CreatedAt = studentTestResult.LastUpdatedAt = DateTime.Now;
                    dbs.StudentTestResults?.Add(studentTestResult);
                    await dbs.SaveChangesAsync();
                    return studentTestResult;
                }
            }
        }

        public async Task<List<StudentTestResult>> GetTestStatus(Guid studentTestId)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                var questions = from test in dbs.Tests
                                join studentTest in dbs.StudentTests on test.Id equals studentTest.TestId
                                join question in dbs.GetFixedQuestions() on test.Id equals question.TestId
                                where studentTest.Id == studentTestId
                                select question;

                var results = from result in dbs.GetFixedStudentTestResults()
                              where result.StudentTestId == studentTestId
                              select result;

                var query = from question in questions
                            join _result in results on question.Id equals _result.QuestionId into g
                            from result in g.DefaultIfEmpty()
                            select new
                            {
                                Question = question,
                                Answer = result
                            };

                var cs = await query.ToListAsync(); //End Sql execute

                var res = from output in cs
                          select new StudentTestResult()
                          {
                              Question = output.Question,
                              Result = output.Answer?.Result
                          };

                bool isRunning = await (
                        from studentTest in dbs.StudentTests
                        join test in dbs.Tests on studentTest.TestId equals test.Id
                        where studentTest.SubmittedOn == null && studentTest.StartDate.Value <= DateTime.Now && DateTime.Now <= studentTest.StartDate.Value.AddMinutes(test.Time.Value)
                        select studentTest
                    ).FirstOrDefaultAsync() == null;

                if (isRunning)
                {
                    foreach (var output in res)
                    {
                        try
                        {
                            var instance = QuestionModelFactory.FromJsonString(output.Question.Content);
                            output.Question.Content = QuestionModelFactory.ToJsonString(instance.AsView());
                        }
                        catch { }
                    }
                }

                return res.ToList();
            }
        }
    }
}
