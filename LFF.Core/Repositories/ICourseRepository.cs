using LFF.Core.Entities;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<Course> GetCourseByIdAsync(Guid id);
        Task<Course> GetCourseByNameAsync(string name);
        Task<bool> CheckCourseExistedByIdAsync(Guid id);
        Task<bool> CheckCourseExistedByNameAsync(string name);
        Task<bool> CheckCourseExistedByNameExceptIdAsync(Guid id, string name);
    }
}
