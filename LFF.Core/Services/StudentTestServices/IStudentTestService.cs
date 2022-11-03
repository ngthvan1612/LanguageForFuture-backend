using LFF.Core.Base;
using LFF.Core.DTOs.Base;
using LFF.Core.DTOs.StudentTests.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LFF.Core.Services.StudentTestServices
{
    public interface IStudentTestService
    {
        Task<ResponseBase> CreateStudentTestAsync(CreateStudentTestRequest request);
        Task<ResponseBase> UpdateStudentTestByIdAsync(Guid id, UpdateStudentTestRequest request);
        Task<ResponseBase> GetStudentTestByIdAsync(Guid id);
        Task<ResponseBase> ListStudentTestAsync(IEnumerable<SearchQueryItem> queries);
        Task<ResponseBase> DeleteStudentTestByIdAsync(Guid id);
    }
}
