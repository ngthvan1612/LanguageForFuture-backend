using LFF.Core.Base;
using LFF.Core.DTOs.Base;
using LFF.Core.DTOs.Users.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LFF.Core.Services.UserServices
{
    public interface IUserService
    {
        Task<ResponseBase> CreateUserAsync(CreateUserRequest request);
        Task<ResponseBase> UpdateUserByIdAsync(Guid id, UpdateUserRequest request);
        Task<ResponseBase> GetUserByIdAsync(Guid id);
        Task<ResponseBase> GetUserByUsernameAsync(string username);
        Task<ResponseBase> GetUserByEmailAsync(string email);
        Task<ResponseBase> GetUserByCMNDAsync(string cMND);
        Task<ResponseBase> UserLogin(UserLoginRequest request);
        Task<ResponseBase> ListUserAsync(IEnumerable<SearchQueryItem> queries);
        Task<ResponseBase> DeleteUserByIdAsync(Guid id);
    }
}
