using LFF.Core.Entities;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Repositories
{
    public interface IStudentTestRepository : IRepository<StudentTest>
    {
        Task<StudentTest> GetStudentTestByIdAsync(Guid id);
        Task<bool> CheckStudentTestExistedByIdAsync(Guid id);
    }
}
