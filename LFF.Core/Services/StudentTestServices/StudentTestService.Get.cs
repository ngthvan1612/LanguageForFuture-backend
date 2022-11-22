using LFF.Core.Base;
using LFF.Core.DTOs.Base;
using LFF.Core.DTOs.StudentTests.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LFF.Core.Services.StudentTestServices
{
    public partial class StudentTestService
    {

        public virtual async Task<ResponseBase> GetStudentTestByIdAsync(Guid id)
        {
            var studentTestRepository = this.aggregateRepository.StudentTestRepository;

            var entity = await studentTestRepository.GetStudentTestByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy học viên kiểm tra nào với Id = {id}");

            return await Task.FromResult(new GetStudentTestResponse(entity));
        }

        public virtual async Task<ResponseBase> ListStudentTestAsync(IEnumerable<SearchQueryItem> queries)
        {
            var studentTestRepository = this.aggregateRepository.StudentTestRepository;

            var raws = await studentTestRepository.ListByQueriesAsync(queries);
            return await Task.FromResult(new ListStudentTestResponse(raws));
        }

        public async Task<ResponseBase> GetStudentTestHistory(Guid studentId, Guid testId)
        {
            var result = await this.aggregateRepository.TestRepository.GetStudentTestHistory(studentId, testId);
            return new StudentTestHistoryResponse(result);
        }
    }
}
