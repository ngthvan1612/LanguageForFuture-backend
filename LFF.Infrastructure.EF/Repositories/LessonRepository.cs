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
    public class LessonRepository : RepositoryBase<Lesson>, ILessonRepository
    {
        private readonly IDbContextFactory<AppDbContext> dbFactory;

        public LessonRepository(IDbContextFactory<AppDbContext> dbFactory)
          : base(dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public async Task<Lesson> GetLessonByIdAsync(Guid id)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseGetAsync(u => u.Id == id);
            }
        }

        public async Task<bool> CheckLessonExistedByIdAsync(Guid id)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseAnyAsync(u => u.Id == id);
            }
        }

        private IQueryable<Lesson> BuildExecuteListQueries(AppDbContext dbs, IEnumerable<SearchQueryItem> queries)
        {
            var query = dbs.Set<Lesson>().Select(u => u).Where(u => u.DeletedAt == null);
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
                else if (tokens[0] == "starttime")
                {
                    if (tokens[1] == "min")
                        query = query.Where(u => u.StartTime >= DateTime.Parse(q.Values[0]));
                    else if (tokens[1] == "max")
                        query = query.Where(u => u.StartTime <= DateTime.Parse(q.Values[0]));
                    else if (tokens[1] == "equal")
                        query = query.Where(u => u.StartTime == DateTime.Parse(q.Values[0]));
                    else throw new ArgumentException($"Unknown query {q.Name}");
                }
                else if (tokens[0] == "endtime")
                {
                    if (tokens[1] == "min")
                        query = query.Where(u => u.EndTime >= DateTime.Parse(q.Values[0]));
                    else if (tokens[1] == "max")
                        query = query.Where(u => u.EndTime <= DateTime.Parse(q.Values[0]));
                    else if (tokens[1] == "equal")
                        query = query.Where(u => u.EndTime == DateTime.Parse(q.Values[0]));
                    else throw new ArgumentException($"Unknown query {q.Name}");
                }
                else if (tokens[0] == "classroom_id")
                {
                    if (tokens[1] == "equal")
                    {
                        Guid guid = Guid.Parse(Convert.ToString(q.Values[0]));
                        query = from lesson in query
                                where lesson.ClassId == guid
                                select lesson;
                    }
                    else throw new ArgumentException($"Unknown query {q.Name}");
                }
                else if (tokens[0] == "student_id")
                {
                    if (tokens[1] == "equal")
                    {
                        Guid studentId = Guid.Parse(q.Values[0]);

                        query = from lesson in query
                                join classroom in dbs.GetFixedClassrooms() on lesson.ClassId equals classroom.Id
                                join register in dbs.GetFixedRegisters() on classroom.Id equals register.ClassId
                                join student in dbs.GetFixedUsers() on register.StudentId equals student.Id
                                where student.Id == studentId
                                select lesson;
                    }
                    else throw new ArgumentException($"Unknown query {q.Name}");
                }
                else throw new ArgumentException($"Unknown query {q.Name}");
            }

            query = query.Include(u => u.Class);

            query = query.Select(u => new Lesson()
            {
                Id = u.Id,
                StartTime = u.StartTime,
                EndTime = u.EndTime,
                CreatedAt = u.CreatedAt,
                DeletedAt = u.DeletedAt,
                Description = u.Description,
                ClassId = u.ClassId,
                Class = u.Class,
                LastUpdatedAt = u.LastUpdatedAt,
                IsApproved = u.IsApproved,
                ReasonForNotApproving = u.ReasonForNotApproving,
                //LessonContent = u.LessonContent,
                Name = u.Name
            });

            return query;
        }

        public override async Task<IEnumerable<Lesson>> ListByQueriesAsync(IEnumerable<SearchQueryItem> queries)
        {
            throw new NotImplementedException("Not used");
        }

        public async Task UpdateLessonContentByLessonIdAsync(Lesson lesson)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                var entity = await dbs.Lessons.FirstOrDefaultAsync(u => u.Id == lesson.Id);
                entity.LessonContent = lesson.LessonContent;
                dbs.Update(entity);
                await dbs.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Lesson>> ListByQueriesAsync(IEnumerable<SearchQueryItem> queries, bool includeNotApprovingLesson)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                var query = this.BuildExecuteListQueries(dbs, queries);
                if (!includeNotApprovingLesson)
                    query = query.Where(u => u.IsApproved == true);
                return await query.ToListAsync();
            }
        }

        public async Task UpdateApprovalAsync(Lesson lesson)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                dbs.Lessons?.Attach(lesson);

                dbs.Entry<Lesson>(lesson).Property(u => u.ReasonForNotApproving).IsModified = true;
                dbs.Entry<Lesson>(lesson).Property(u => u.IsApproved).IsModified = true;

                await dbs.SaveChangesAsync();
            }
        }
    }
}
