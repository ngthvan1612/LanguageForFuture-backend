using LFF.Core.Base;
using LFF.Core.DTOs.Base;
using LFF.Core.DTOs.Classrooms.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LFF.Core.Services.ClassroomServices
{
    public interface IClassroomService
    {
        Task<ResponseBase> CreateClassroomAsync(CreateClassroomRequest request);
        Task<ResponseBase> UpdateClassroomByIdAsync(Guid id, UpdateClassroomRequest request);
        Task<ResponseBase> GetClassroomByIdAsync(Guid id);
        Task<ResponseBase> GetClassroomByNameAsync(string name);
        Task<ResponseBase> ListClassroomAsync(IEnumerable<SearchQueryItem> queries);
        Task<ResponseBase> DeleteClassroomByIdAsync(Guid id);
    }
}
