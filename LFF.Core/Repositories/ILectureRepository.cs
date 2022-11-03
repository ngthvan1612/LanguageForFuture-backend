using LFF.Core.Entities;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Repositories
{
    public interface ILectureRepository : IRepository<Lecture>
    {
        Task<Lecture> GetLectureByIdAsync(Guid id);
        Task<bool> CheckLectureExistedByIdAsync(Guid id);
    }
}
