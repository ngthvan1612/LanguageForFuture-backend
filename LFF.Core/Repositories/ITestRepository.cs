using LFF.Core.Entities;
using LFF.Core.Entities.Supports;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LFF.Core.Repositories
{
    public interface ITestRepository : IRepository<Test>
    {
        Task<Test> GetTestByIdAsync(Guid id);
        Task<StudentTestHistory> GetStudentTestHistory(Guid studentId, Guid testId);
        Task<bool> CheckTestExistedByIdAsync(Guid id);
        Task<int> NumberOfTimesAttemptTest(Guid studentId, Guid testId);
        Task<bool> IsDoingAnyTest(Guid studentId);
        Task ImportListQuestions(Guid testId, Stream stream);
    }
}
