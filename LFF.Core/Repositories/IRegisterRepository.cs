using LFF.Core.Entities;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Repositories
{
    public interface IRegisterRepository : IRepository<Register>
    {
        Task<Register> GetRegisterByIdAsync(Guid id);
        Task<bool> CheckRegisterExistedByIdAsync(Guid id);
        Task<bool> CheckRegisterExistedByStudentAndClassId(Guid studentId, Guid classId);
    }
}
