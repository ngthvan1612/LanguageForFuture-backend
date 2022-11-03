using LFF.Core.Entities;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Repositories
{
    public interface ITestRepository : IRepository<Test>
    {
        Task<Test> GetTestByIdAsync(Guid id);
        Task<bool> CheckTestExistedByIdAsync(Guid id);
    }
}
