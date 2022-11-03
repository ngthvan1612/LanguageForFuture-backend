using LFF.Core.Base;
using LFF.Core.DTOs.Base;
using LFF.Core.DTOs.Questions.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LFF.Core.Services.QuestionServices
{
    public interface IQuestionService
    {
        Task<ResponseBase> CreateQuestionAsync(CreateQuestionRequest request);
        Task<ResponseBase> UpdateQuestionByIdAsync(Guid id, UpdateQuestionRequest request);
        Task<ResponseBase> GetQuestionByIdAsync(Guid id);
        Task<ResponseBase> ListQuestionAsync(IEnumerable<SearchQueryItem> queries);
        Task<ResponseBase> DeleteQuestionByIdAsync(Guid id);
    }
}
