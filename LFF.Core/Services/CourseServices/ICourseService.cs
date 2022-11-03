using LFF.Core.Base;
using LFF.Core.DTOs.Base;
using LFF.Core.DTOs.Courses.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LFF.Core.Services.CourseServices
{
    public interface ICourseService
    {
        Task<ResponseBase> CreateCourseAsync(CreateCourseRequest request);
        Task<ResponseBase> UpdateCourseByIdAsync(Guid id, UpdateCourseRequest request);
        Task<ResponseBase> GetCourseByIdAsync(Guid id);
        Task<ResponseBase> GetCourseByNameAsync(string name);
        Task<ResponseBase> ListCourseAsync(IEnumerable<SearchQueryItem> queries);
        Task<ResponseBase> DeleteCourseByIdAsync(Guid id);
    }
}
