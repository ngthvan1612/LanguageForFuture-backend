using LFF.Core.Entities;
using LFF.Infrastructure.EF.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LFF.Infrastructure.EF.DataAccess
{
    public class AppDbContext : DbContext
    {
        private static readonly bool isCreated = false;

        public DbSet<User>? Users { get; set; }

        public DbSet<Course>? Courses { get; set; }

        public DbSet<Classroom>? Classrooms { get; set; }

        public DbSet<Lesson>? Lessons { get; set; }

        //public DbSet<Lecture>? Lectures { get; set; }

        public DbSet<Register>? Registers { get; set; }

        public DbSet<Test>? Tests { get; set; }

        public DbSet<Question>? Questions { get; set; }

        public DbSet<StudentTest>? StudentTests { get; set; }

        public DbSet<StudentTestResult>? StudentTestResults { get; set; }

        public IQueryable<User> GetFixedUsers() => this.Users.Where(u => u.DeletedAt == null);
        public IQueryable<Course> GetFixedCourses() => this.Courses.Where(u => u.DeletedAt == null);
        public IQueryable<Classroom> GetFixedClassrooms() => this.Classrooms.Where(u => u.DeletedAt == null);
        public IQueryable<Register> GetFixedRegisters() => this.Registers.Where(u => u.DeletedAt == null);
        public IQueryable<Test> GetFixedTests() => this.Tests.Where(u => u.DeletedAt == null);
        public IQueryable<Question> GetFixedQuestions() => this.Questions.Where(u => u.DeletedAt == null);
        public IQueryable<StudentTest> GetFixedStudentTests() => this.StudentTests.Where(u => u.DeletedAt == null);
        public IQueryable<StudentTestResult> GetFixedStudentTestResults() => this.StudentTestResults.Where(u => u.DeletedAt == null);

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            //Dùng migration, không bật cái này lên
            //this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new ClassroomConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new LectureConfiguration());
            modelBuilder.ApplyConfiguration(new RegisterConfiguration());
            modelBuilder.ApplyConfiguration(new TestConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new StudentTestConfiguration());
            modelBuilder.ApplyConfiguration(new StudentTestResultConfiguration());
        }
    }
}
