using LFF.Core.Base;
using LFF.Core.DTOs.Base;
using LFF.Core.DTOs.Registers.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LFF.Core.Services.RegisterServices
{
    public partial class RegisterService
    {

        public virtual async Task<ResponseBase> GetRegisterByIdAsync(Guid id)
        {
            var registerRepository = this.aggregateRepository.RegisterRepository;

            var entity = await registerRepository.GetRegisterByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy đăng ký nào với Id = {id}");

            return await Task.FromResult(new GetRegisterResponse(entity));
        }

        public virtual async Task<ResponseBase> ListRegisterAsync(IEnumerable<SearchQueryItem> queries)
        {
            var registerRepository = this.aggregateRepository.RegisterRepository;

            var raws = await registerRepository.ListByQueriesAsync(queries);
            return await Task.FromResult(new ListRegisterResponse(raws));
        }
    }
}
