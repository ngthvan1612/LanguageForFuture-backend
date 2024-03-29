using LFF.Core.Entities;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Repositories
{
    public interface IStudentTestResultRepository : IRepository<StudentTestResult>
    {
        Task<StudentTestResult> GetStudentTestResultByIdAsync(Guid id);
        Task<bool> CheckStudentTestResultExistedByIdAsync(Guid id);
        Task<StudentTestResult> CreateOrUpdateResult(StudentTestResult studentTestResult);
    }
}
