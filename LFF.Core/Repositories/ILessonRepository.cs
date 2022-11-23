using LFF.Core.Entities;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Repositories
{
    public interface ILessonRepository : IRepository<Lesson>
    {
        Task UpdateLessonContentByLessonIdAsync(Lesson lesson);
        Task<Lesson> GetLessonByIdAsync(Guid id);
        Task<bool> CheckLessonExistedByIdAsync(Guid id);
    }
}
