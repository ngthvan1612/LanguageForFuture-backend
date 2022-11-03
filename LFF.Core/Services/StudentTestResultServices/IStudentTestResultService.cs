using LFF.Core.Base;
using LFF.Core.DTOs.Base;
using LFF.Core.DTOs.StudentTestResults.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LFF.Core.Services.StudentTestResultServices
{
    public interface IStudentTestResultService
    {
        Task<ResponseBase> CreateStudentTestResultAsync(CreateStudentTestResultRequest request);
        Task<ResponseBase> UpdateStudentTestResultByIdAsync(Guid id, UpdateStudentTestResultRequest request);
        Task<ResponseBase> GetStudentTestResultByIdAsync(Guid id);
        Task<ResponseBase> ListStudentTestResultAsync(IEnumerable<SearchQueryItem> queries);
        Task<ResponseBase> DeleteStudentTestResultByIdAsync(Guid id);
    }
}
