using LFF.Core.DTOs.Base;
using LFF.Core.Entities;
using LFF.Core.Repositories;
using LFF.Infrastructure.EF.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LFF.Infrastructure.EF.Repositories
{
    public class ClassroomRepository : RepositoryBase<Classroom>, IClassroomRepository
    {
        private readonly IDbContextFactory<AppDbContext> dbFactory;

        public ClassroomRepository(IDbContextFactory<AppDbContext> dbFactory)
          : base(dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public async Task<Classroom> GetClassroomByIdAsync(Guid id)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                return await dbs.Classrooms.Where(u => u.Id == id)
                    .Include(u => u.Teacher)
                    .Include(u => u.Course)
                    .Include(u => u.Lessons)
                    .FirstOrDefaultAsync();
            }
        }

        public async Task<Classroom> GetClassroomByNameAsync(string name)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseGetAsync(u => u.Name == name);
            }
        }

        public async Task<bool> CheckClassroomExistedByIdAsync(Guid id)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseAnyAsync(u => u.Id == id);
            }
        }

        public async Task<bool> CheckClassroomExistedByNameAsync(string name)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseAnyAsync(u => u.Name == name);
            }
        }

        public async Task<bool> CheckClassroomExistedByNameExceptIdAsync(Guid id, string name)
        {
            using (this.dbFactory.CreateDbContext())
            {
                return await base.BaseAnyAsync(u => u.Name == name && u.Id != id);
            }
        }

        public override async Task<IEnumerable<Classroom>> ListByQueriesAsync(IEnumerable<SearchQueryItem> queries)
        {
            using (var dbs = this.dbFactory.CreateDbContext())
            {
                var query = dbs.Set<Classroom>().Select(u => u).Where(u => u.DeletedAt == null);
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
                    else if (tokens[0] == "numberoflessons")
                    {
                        if (tokens[1] == "min")
                            query = query.Where(u => double.Parse(q.Values[0]) <= u.NumberOfLessons);
                        else if (tokens[1] == "max")
                            query = query.Where(u => u.NumberOfLessons <= double.Parse(q.Values[0]));
                        else if (tokens[1] == "equal")
                            query = query.Where(u => double.Parse(q.Values[0]) == u.NumberOfLessons);
                        else throw new ArgumentException($"Unknown query {q.Name}");
                    }
                    else if (tokens[0] == "student_id")
                    {
                        if (tokens[1] == "equal")
                        {
                            Guid guid = Guid.Parse(Convert.ToString(q.Values[0]));
                            query = from classroom in query
                                    join register in dbs.Registers on classroom.Id equals register.ClassId
                                    join student in dbs.Users on register.StudentId equals student.Id
                                    where student.Id == guid
                                    select classroom;
                        }
                    }
                    else if (tokens[0] == "teacher_id")
                    {
                        if (tokens[1] == "equal")
                        {
                            Guid guid = Guid.Parse(Convert.ToString(q.Values[0]));
                            query = from classroom in query
                                    join teacher in dbs.Users on classroom.TeacherId equals teacher.Id
                                    where teacher.Id == guid
                                    select classroom;
                        }
                    }
                    else throw new ArgumentException($"Unknown query {q.Name}");
                }

                var teachers = from user in dbs.Users
                               where user.DeletedAt == null && user.Role == UserRoles.Teacher
                               select user;

                var courses = from course in dbs.Courses
                              where course.DeletedAt == null
                              select course;

                var join = from classroom in query
                             join teacher in teachers on classroom.TeacherId equals teacher.Id
                             join course in courses on classroom.CourseId equals course.Id
                             select new { classroom = classroom, teacher = teacher, course = course };

                var result = await join.ToListAsync();

                foreach (var item in result)
                {
                    item.classroom.Course = item.course;
                    item.classroom.Teacher = item.teacher;
                }

                return result.Select(u => u.classroom);
            }
        }
    }
}
