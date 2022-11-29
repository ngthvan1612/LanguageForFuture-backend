using LFF.Core.DTOs.Base;
using LFF.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LFF.Core.Repositories
{
    public interface ILessonRepository : IRepository<Lesson>
    {
        Task<IEnumerable<Lesson>> ListByQueriesAsync(IEnumerable<SearchQueryItem> queries, bool includeNotApprovingLesson);
        Task UpdateLessonContentByLessonIdAsync(Lesson lesson);
        Task<Lesson> GetLessonByIdAsync(Guid id);
        Task<bool> CheckLessonExistedByIdAsync(Guid id);
        Task UpdateApprovalAsync(Lesson lesson);
    }
}
