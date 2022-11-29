using LFF.Core.Base;
using LFF.Core.DTOs.Base;
using LFF.Core.DTOs.Lessons.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LFF.Core.Services.LessonServices
{
    public partial class LessonService
    {

        public virtual async Task<ResponseBase> GetLessonByIdAsync(Guid id)
        {
            var lessonRepository = this.aggregateRepository.LessonRepository;

            var entity = await lessonRepository.GetLessonByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy buổi học nào với Id = {id}");

            return await Task.FromResult(new GetLessonResponse(entity));
        }

        public virtual async Task<ResponseBase> ListLessonAsync(IEnumerable<SearchQueryItem> queries, bool includeNotApprovingLesson)
        {
            var lessonRepository = this.aggregateRepository.LessonRepository;

            var raws = await lessonRepository.ListByQueriesAsync(queries, includeNotApprovingLesson);
            return await Task.FromResult(new ListLessonResponse(raws));
        }
    }
}
