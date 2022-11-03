using LFF.Core.Base;
using LFF.Core.DTOs.Base;
using LFF.Core.DTOs.Tests.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LFF.Core.Services.TestServices
{
    public interface ITestService
    {
        Task<ResponseBase> CreateTestAsync(CreateTestRequest request);
        Task<ResponseBase> UpdateTestByIdAsync(Guid id, UpdateTestRequest request);
        Task<ResponseBase> GetTestByIdAsync(Guid id);
        Task<ResponseBase> ListTestAsync(IEnumerable<SearchQueryItem> queries);
        Task<ResponseBase> DeleteTestByIdAsync(Guid id);
    }
}
