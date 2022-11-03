using LFF.Core.Base;
using LFF.Core.DTOs.Base;
using LFF.Core.DTOs.Tests.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LFF.Core.Services.TestServices
{
    public partial class TestService
    {

        public virtual async Task<ResponseBase> GetTestByIdAsync(Guid id)
        {
            var testRepository = this.aggregateRepository.TestRepository;

            var entity = await testRepository.GetTestByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy bài kiểm tra nào với Id = {id}");

            return await Task.FromResult(new GetTestResponse(entity));
        }

        public virtual async Task<ResponseBase> ListTestAsync(IEnumerable<SearchQueryItem> queries)
        {
            var testRepository = this.aggregateRepository.TestRepository;

            var raws = await testRepository.ListByQueriesAsync(queries);
            return await Task.FromResult(new ListTestResponse(raws));
        }
    }
}
