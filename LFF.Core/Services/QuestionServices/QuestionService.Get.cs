using LFF.Core.Base;
using LFF.Core.DTOs.Base;
using LFF.Core.DTOs.Questions.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LFF.Core.Services.QuestionServices
{
    public partial class QuestionService
    {

        public virtual async Task<ResponseBase> GetQuestionByIdAsync(Guid id)
        {
            var questionRepository = this.aggregateRepository.QuestionRepository;

            var entity = await questionRepository.GetQuestionByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy câu hỏi nào với Id = {id}");

            return await Task.FromResult(new GetQuestionResponse(entity));
        }

        public virtual async Task<ResponseBase> ListQuestionAsync(IEnumerable<SearchQueryItem> queries)
        {
            var questionRepository = this.aggregateRepository.QuestionRepository;

            var raws = await questionRepository.ListByQueriesAsync(queries);
            return await Task.FromResult(new ListQuestionResponse(raws));
        }
    }
}
