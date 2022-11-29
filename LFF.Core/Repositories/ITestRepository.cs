using LFF.Core.Entities;
using LFF.Core.Entities.Supports;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Repositories
{
    public interface ITestRepository : IRepository<Test>
    {
        Task<Test> GetTestByIdAsync(Guid id);
        Task<StudentTestHistory> GetStudentTestHistory(Guid studentId, Guid testId);
        Task<bool> CheckTestExistedByIdAsync(Guid id);
        Task<bool> IsDoingAnyTest(Guid studentId);
        Task<bool> DeleteAsync(T entity);
    }
}
