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
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<ICourseRepository, CourseRepository>();
            services.AddSingleton<IClassroomRepository, ClassroomRepository>();
            services.AddSingleton<ILessonRepository, LessonRepository>();
            services.AddSingleton<ILectureRepository, LectureRepository>();
            services.AddSingleton<IRegisterRepository, RegisterRepository>();
            services.AddSingleton<ITestRepository, TestRepository>();
            services.AddSingleton<IQuestionRepository, QuestionRepository>();
            services.AddSingleton<IStudentTestRepository, StudentTestRepository>();
            services.AddSingleton<IStudentTestResultRepository, StudentTestResultRepository>();

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
