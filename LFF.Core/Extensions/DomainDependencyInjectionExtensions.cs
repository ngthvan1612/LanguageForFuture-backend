using LFF.Core.Services.ClassroomServices;
using LFF.Core.Services.CourseServices;
using LFF.Core.Services.LectureServices;
using LFF.Core.Services.LessonServices;
using LFF.Core.Services.QuestionServices;
using LFF.Core.Services.RegisterServices;
using LFF.Core.Services.StudentTestResultServices;
using LFF.Core.Services.StudentTestServices;
using LFF.Core.Services.TestServices;
using LFF.Core.Services.UserServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LFF.Core.Extensions
{
    public static class DomainDependencyInjectionExtensions
    {

        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IClassroomService, ClassroomService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<ILectureService, LectureService>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IStudentTestService, StudentTestService>();
            services.AddScoped<IStudentTestResultService, StudentTestResultService>();

            return services;
        }
    }
}
