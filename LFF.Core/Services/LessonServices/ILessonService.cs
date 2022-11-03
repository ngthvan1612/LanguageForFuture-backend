using LFF.Core.Base;
using LFF.Core.DTOs.Base;
using LFF.Core.DTOs.Lessons.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LFF.Core.Services.LessonServices
{
    public interface ILessonService
    {
        Task<ResponseBase> CreateLessonAsync(CreateLessonRequest request);
        Task<ResponseBase> UpdateLessonByIdAsync(Guid id, UpdateLessonRequest request);
        Task<ResponseBase> GetLessonByIdAsync(Guid id);
        Task<ResponseBase> ListLessonAsync(IEnumerable<SearchQueryItem> queries);
        Task<ResponseBase> DeleteLessonByIdAsync(Guid id);
    }
}
