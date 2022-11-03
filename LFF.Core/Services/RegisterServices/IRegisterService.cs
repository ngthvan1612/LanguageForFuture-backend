using LFF.Core.Base;
using LFF.Core.DTOs.Base;
using LFF.Core.DTOs.Registers.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LFF.Core.Services.RegisterServices
{
    public interface IRegisterService
    {
        Task<ResponseBase> CreateRegisterAsync(CreateRegisterRequest request);
        Task<ResponseBase> UpdateRegisterByIdAsync(Guid id, UpdateRegisterRequest request);
        Task<ResponseBase> GetRegisterByIdAsync(Guid id);
        Task<ResponseBase> ListRegisterAsync(IEnumerable<SearchQueryItem> queries);
        Task<ResponseBase> DeleteRegisterByIdAsync(Guid id);
    }
}
