using LFF.Core.Base;
using LFF.Core.DTOs.Base;
using LFF.Core.DTOs.Lectures.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LFF.Core.Services.LectureServices
{
    public interface ILectureService
    {
        Task<ResponseBase> CreateLectureAsync(CreateLectureRequest request);
        Task<ResponseBase> UpdateLectureByIdAsync(Guid id, UpdateLectureRequest request);
        Task<ResponseBase> GetLectureByIdAsync(Guid id);
        Task<ResponseBase> ListLectureAsync(IEnumerable<SearchQueryItem> queries);
        Task<ResponseBase> DeleteLectureByIdAsync(Guid id);
    }
}
