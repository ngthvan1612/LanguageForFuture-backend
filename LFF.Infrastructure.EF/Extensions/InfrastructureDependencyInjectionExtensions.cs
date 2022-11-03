using LFF.Core.Repositories;
using LFF.Infrastructure.EF.DataAccess;
using LFF.Infrastructure.EF.Repositories;
using LFF.Infrastructure.EF.Utils.PasswordUtils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LFF.Infrastructure.EF.Extensions
{
    public static class InfrastructureDependencyInjectionExtensions
    {

        public static IServiceCollection RegisterRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IClassroomRepository, ClassroomRepository>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<ILectureRepository, LectureRepository>();
            services.AddScoped<IRegisterRepository, RegisterRepository>();
            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IStudentTestRepository, StudentTestRepository>();
            services.AddScoped<IStudentTestResultRepository, StudentTestResultRepository>();

            services.AddScoped<IAggregateRepository, AggregateRepository>();

            services.AddSingleton<PasswordHasherManaged>();
            return services;
        }

        public static IServiceCollection RegisterEFDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<AppDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
