using LFF.Core.DTOs.Base;
using LFF.Core.Entities;
using LFF.Core.Entities.Supports;
using LFF.Core.Repositories;
using LFF.Core.Utils.Questions;
using LFF.Infrastructure.EF.DataAccess;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LFF.Infrastructure.EF.Repositories
{
    public class TestRepository : RepositoryBase<Test>, ITestRepository
    {
        private readonly IDbContextFactory<AppDbContext> dbFactory;

        public TestRepository(IDbContextFactory<AppDbContext> dbFactory)
          : base(dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public async Task<Test> GetTestByIdAsync(Guid id)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseGetAsync(u => u.Id == id);
            }
        }

        public async Task<bool> CheckTestExistedByIdAsync(Guid id)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseAnyAsync(u => u.Id == id);
            }
        }

        public override async Task<IEnumerable<Test>> ListByQueriesAsync(IEnumerable<SearchQueryItem> queries)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                var query = dbs.Set<Test>().Select(u => u).Where(u => u.DeletedAt == null);
                foreach (var q in queries)
                {
                    var tokens = q.Name.ToLower().Split(".");
                    if (tokens.Length < 2 || q.Values.Count == 0)
                        throw new ArgumentException($"Tham số không hợp lệ '{q.Name}'");
                    if (tokens[0] == "name")
                    {
                        if (tokens[1] == "startswith")
                            query = query.Where(u => u.Name.StartsWith(q.Values[0]));
                        else if (tokens[1] == "endswith")
                            query = query.Where(u => u.Name.EndsWith(q.Values[0]));
                        else if (tokens[1] == "contains")
                            query = query.Where(u => u.Name.Contains(q.Values[0]));
                        else if (tokens[1] == "equal")
                            query = query.Where(u => u.Name == q.Values[0]);
                        else throw new ArgumentException($"Unknown query {q.Name}");
                    }
                    else if (tokens[0] == "description")
                    {
                        if (tokens[1] == "startswith")
                            query = query.Where(u => u.Description.StartsWith(q.Values[0]));
                        else if (tokens[1] == "endswith")
                            query = query.Where(u => u.Description.EndsWith(q.Values[0]));
                        else if (tokens[1] == "contains")
                            query = query.Where(u => u.Description.Contains(q.Values[0]));
                        else if (tokens[1] == "equal")
                            query = query.Where(u => u.Description == q.Values[0]);
                        else throw new ArgumentException($"Unknown query {q.Name}");
                    }
                    else if (tokens[0] == "startdate")
                    {
                        if (tokens[1] == "min")
                            query = query.Where(u => u.StartDate >= DateTime.Parse(q.Values[0]));
                        else if (tokens[1] == "max")
                            query = query.Where(u => u.StartDate <= DateTime.Parse(q.Values[0]));
                        else if (tokens[1] == "equal")
                            query = query.Where(u => u.StartDate == DateTime.Parse(q.Values[0]));
                        else throw new ArgumentException($"Unknown query {q.Name}");
                    }
                    else if (tokens[0] == "enddate")
                    {
                        if (tokens[1] == "min")
                            query = query.Where(u => u.EndDate >= DateTime.Parse(q.Values[0]));
                        else if (tokens[1] == "max")
                            query = query.Where(u => u.EndDate <= DateTime.Parse(q.Values[0]));
                        else if (tokens[1] == "equal")
                            query = query.Where(u => u.EndDate == DateTime.Parse(q.Values[0]));
                        else throw new ArgumentException($"Unknown query {q.Name}");
                    }
                    else if (tokens[0] == "numberofattempts")
                    {
                        if (tokens[1] == "min")
                            query = query.Where(u => double.Parse(q.Values[0]) <= u.NumberOfAttempts);
                        else if (tokens[1] == "max")
                            query = query.Where(u => u.NumberOfAttempts <= double.Parse(q.Values[0]));
                        else if (tokens[1] == "equal")
                            query = query.Where(u => double.Parse(q.Values[0]) == u.NumberOfAttempts);
                        else throw new ArgumentException($"Unknown query {q.Name}");
                    }
                    else if (tokens[0] == "time")
                    {
                        if (tokens[1] == "min")
                            query = query.Where(u => u.Time >= int.Parse(q.Values[0]));
                        else if (tokens[1] == "max")
                            query = query.Where(u => u.Time <= int.Parse(q.Values[0]));
                        else if (tokens[1] == "equal")
                            query = query.Where(u => u.Time == int.Parse(q.Values[0]));
                        else throw new ArgumentException($"Unknown query {q.Name}");
                    }
                    else if (tokens[0] == "lesson_id")
                    {
                        if (tokens[1] == "equal")
                        {
                            Guid guid = Guid.Parse(Convert.ToString(q.Values[0]));
                            query = query.Where(u => u.LessonId == guid);
                        }
                        else throw new ArgumentException($"Unknown query {q.Name}");
                    }
                    else throw new ArgumentException($"Unknown query {q.Name}");
                }

                var lessons = from lesson in dbs.Lessons
                              where lesson.DeletedAt == null
                              select lesson;

                var linq = from test in query
                           join lesson in lessons on test.LessonId equals lesson.Id
                           select new
                           {
                               test = test,
                               lesson = lesson
                           };

                var result = (await linq.ToListAsync())
                    .Select(u =>
                    {
                        u.test.Lesson = u.lesson;
                        return u.test;
                    });

                return result;
            }
        }

        public async Task<StudentTestHistory> GetStudentTestHistory(Guid studentId, Guid testId)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                //SQL PROCESSING
                var testEntity = dbs.Tests.FirstOrDefault(u => u.Id == testId);
                var studentEntity = dbs.Users.FirstOrDefault(u => u.Id == studentId && u.DeletedAt == null);

                //var fixedStudentTests = dbs.StudentTests.Where(u => u.DeletedAt == null)
                //    .Where(u => u.SubmittedOn != null || )
                //    .Where(u => u.TestId == testId && u.StudentId == studentId);
                var fixedStudentTests = from studentTest in dbs.GetFixedStudentTests()
                                        join test in dbs.GetFixedTests() on studentTest.TestId equals test.Id
                                        where studentTest.SubmittedOn != null || !(studentTest.StartDate.Value <= DateTime.Now && DateTime.Now <= studentTest.StartDate.Value.AddMinutes(test.Time.Value))
                                        where studentTest.StudentId == studentId && studentTest.TestId == testId
                                        select studentTest;

                var fixedResults = from result in dbs.StudentTestResults
                                              join studentTest in fixedStudentTests on result.StudentTestId equals studentTest.Id
                                              select result;

                var fixedQuestions = dbs.Questions.Where(u => u.DeletedAt == null)
                    .Where(u => u.TestId == testId);

                var questionAndAnswers = await (
                    from question in fixedQuestions
                    join test in dbs.Tests.Where(u => u.Id == testId) on question.TestId equals test.Id
                    join studentTest in fixedStudentTests on test.Id equals studentTest.TestId
                    join _result in fixedResults on new
                    {
                        questionId = question.Id,
                        studentTestId = studentTest.Id
                    } equals new
                    {
                        questionId = _result.QuestionId,
                        studentTestId = _result.StudentTestId
                    } into g
                    from result in g.DefaultIfEmpty()
                    select new
                    {
                        StudentTestId = studentTest.Id ?? Guid.Empty,
                        StartDate = studentTest.StartDate,
                        Question = question,
                        Result = result,
                    }
                ).ToListAsync(); //END-EXECUTE

                //C# PROCESSING
                var query = questionAndAnswers
                    .GroupBy(u => new
                    {
                        StudentTestId = u.StudentTestId,
                        StartDate = u.StartDate
                    })
                    .Select(u => new
                        {
                            StudentTestId = u.Key.StudentTestId,
                            StartDate = u.Key.StartDate,
                            Context = (
                                from v in u
                                select new
                                {
                                    Question = v.Question,
                                    Answer = v.Result
                                }
                            ).ToList()
                        }
                    )
                    .ToList();

                StudentTestHistory model = new StudentTestHistory();

                model.TestInfo = await dbs.Tests.Where(u => u.Id == testId).FirstOrDefaultAsync();
                model.TotalScore = await fixedQuestions.CountAsync();

                if (model.TestInfo.Questions != null)
                    model.TestInfo.Questions.Clear();

                List<StudentTestHistoryItem> histories = new List<StudentTestHistoryItem>();
                model.Histories = histories;

                foreach (var studentTest in query)
                {
                    StudentTestHistoryItem history = new StudentTestHistoryItem();

                    history.StudentTestId = studentTest.StudentTestId;
                    history.StartDate = studentTest.StartDate ?? DateTime.MinValue;
                    history.Score = studentTest.Context.Sum(u =>
                    {
                        var questionModel = QuestionModelFactory.FromJsonString(u.Question.Content ?? "");
                        string? answer = null;
                        if (u.Answer != null)
                        {
                            answer = u.Answer.Result;
                        }
                        return questionModel.CalculateScore(answer);
                    });

                    histories.Add(history);
                }

                return model;
            }
        }

        public async Task<int> NumberOfTimesAttemptTest(Guid studentId, Guid testId)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                return await dbs.StudentTests
                    .Where(u => u.StudentId == studentId && u.TestId == testId)
                    .Where(u => u.DeletedAt == null)
                    .CountAsync();
            }
        }

        public async Task<bool> IsDoingAnyTest(Guid studentId)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                var currentDatetime = DateTime.Now;
                var query = from studentTest in dbs.StudentTests
                            join test in dbs.Tests on studentTest.TestId equals test.Id
                            where
                                studentTest.DeletedAt == null &&
                                test.DeletedAt == null &&
                                studentTest.StudentId == studentId &&
                                studentTest.StartDate <= currentDatetime && currentDatetime <= studentTest.StartDate.Value.AddMinutes(test.Time ?? 0)
                            select 1;
                return await query.AnyAsync();
            }
        }

        public async Task ImportListQuestions(Guid testId, Stream stream)
        {
            using var reader = new StreamReader(stream);
            string jsonStr = await reader.ReadToEndAsync();
            dynamic json;
            List<QuestionModelAbstract> questions = new List<QuestionModelAbstract>();
            try
            {
                json = JsonConvert.DeserializeObject(jsonStr);
            }
            catch (Exception)
            {
                throw new Exception("Không đọc được dữ liệu");
            }
            int counter = 0;
            foreach (var question in json)
            {
                counter++;
                try
                {
                    var questionInstance = QuestionModelFactory.FromJsonString(JsonConvert.SerializeObject(question));
                    questions.Add(questionInstance);
                }
                catch (Exception e)
                {
                    throw new Exception($"Câu {counter} lỗi: {e.Message}");
                }
            }
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                using (var transaction = await dbs.Database.BeginTransactionAsync())
                {
                    try
                    {
                        foreach (var question in questions)
                        {
                            dbs.Questions.Add(new Question()
                            {
                                Content = QuestionModelFactory.ToJsonString(question),
                                CreatedAt = DateTime.Now,
                                LastUpdatedAt = DateTime.Now,
                                QuestionType = "MULTIPLE-CHOICE",
                                TestId = testId
                            });
                        }
                        await dbs.SaveChangesAsync();
                        await transaction.CommitAsync();
                    }
                    catch (Exception e)
                    {
                        await transaction.RollbackAsync();
                        throw new Exception("Không nhập được file", e);
                    }
                }
            }
        }
    }
}
