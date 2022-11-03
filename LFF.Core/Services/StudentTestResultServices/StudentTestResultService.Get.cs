using LFF.Core.Base;
using LFF.Core.DTOs.Base;
using LFF.Core.DTOs.StudentTestResults.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LFF.Core.Services.StudentTestResultServices
{
    public partial class StudentTestResultService
    {

        public virtual async Task<ResponseBase> GetStudentTestResultByIdAsync(Guid id)
        {
            var studentTestResultRepository = this.aggregateRepository.StudentTestResultRepository;

            var entity = await studentTestResultRepository.GetStudentTestResultByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy kết quả kiểm tra nào với Id = {id}");

            return await Task.FromResult(new GetStudentTestResultResponse(entity));
        }

        public virtual async Task<ResponseBase> ListStudentTestResultAsync(IEnumerable<SearchQueryItem> queries)
        {
            var studentTestResultRepository = this.aggregateRepository.StudentTestResultRepository;

            var raws = await studentTestResultRepository.ListByQueriesAsync(queries);
            return await Task.FromResult(new ListStudentTestResultResponse(raws));
        }
    }
}
