using LFF.Core.Entities;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Repositories
{
    public interface IClassroomRepository : IRepository<Classroom>
    {
        Task<Classroom> GetClassroomByIdAsync(Guid id);
        Task<Classroom> GetClassroomByNameAsync(string name);
        Task<bool> CheckClassroomExistedByIdAsync(Guid id);
        Task<bool> CheckClassroomExistedByNameAsync(string name);
        Task<bool> CheckClassroomExistedByNameExceptIdAsync(Guid id, string name);
    }
}
