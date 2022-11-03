using LFF.Core.Base;
using LFF.Core.DTOs.Base;
using LFF.Core.DTOs.Lectures.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LFF.Core.Services.LectureServices
{
    public partial class LectureService
    {

        public virtual async Task<ResponseBase> GetLectureByIdAsync(Guid id)
        {
            var lectureRepository = this.aggregateRepository.LectureRepository;

            var entity = await lectureRepository.GetLectureByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy bài giảng nào với Id = {id}");

            return await Task.FromResult(new GetLectureResponse(entity));
        }

        public virtual async Task<ResponseBase> ListLectureAsync(IEnumerable<SearchQueryItem> queries)
        {
            var lectureRepository = this.aggregateRepository.LectureRepository;

            var raws = await lectureRepository.ListByQueriesAsync(queries);
            return await Task.FromResult(new ListLectureResponse(raws));
        }
    }
}
