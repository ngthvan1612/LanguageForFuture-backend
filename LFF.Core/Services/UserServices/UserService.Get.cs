using LFF.Core.Base;
using LFF.Core.DTOs.Base;
using LFF.Core.DTOs.Users.Requests;
using LFF.Core.DTOs.Users.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LFF.Core.Services.UserServices
{
    public partial class UserService
    {
        public virtual async Task<ResponseBase> GetUserByIdAsync(Guid id)
        {
            var userRepository = this.aggregateRepository.UserRepository;

            var entity = await userRepository.GetUserByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy người dùng nào với Id = {id}");

            return await Task.FromResult(new GetUserResponse(entity));
        }

        public virtual async Task<ResponseBase> GetUserByUsernameAsync(string username)
        {
            var userRepository = this.aggregateRepository.UserRepository;

            var entity = await userRepository.GetUserByUsernameAsync(username);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy người dùng nào với tên người dùng = {username}");

            return await Task.FromResult(new GetUserResponse(entity));
        }

        public virtual async Task<ResponseBase> GetUserByEmailAsync(string email)
        {
            var userRepository = this.aggregateRepository.UserRepository;

            var entity = await userRepository.GetUserByEmailAsync(email);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy người dùng nào với email = {email}");

            return await Task.FromResult(new GetUserResponse(entity));
        }

        public virtual async Task<ResponseBase> GetUserByCMNDAsync(string cMND)
        {
            var userRepository = this.aggregateRepository.UserRepository;

            var entity = await userRepository.GetUserByCMNDAsync(cMND);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy người dùng nào với Chứng minh nhân dân = {cMND}");

            return await Task.FromResult(new GetUserResponse(entity));
        }

        public async Task<ResponseBase> UserLogin(UserLoginRequest request)
        {
            var userRepository = this.aggregateRepository.UserRepository;

            var user = await userRepository.GetUserByUsernameAndPassword(request.Username, request.Password);

            if (user != null)
            {
                return new AuthenticatedUserResponse(user);
            }
            else
            {
                throw BaseDomainException.UnAuthentication("Tên đăng nhập hoặc mật khẩu không đúng");
            }
        }

        public virtual async Task<ResponseBase> ListUserAsync(IEnumerable<SearchQueryItem> queries)
        {
            var userRepository = this.aggregateRepository.UserRepository;

            var raws = await userRepository.ListByQueriesAsync(queries);
            return await Task.FromResult(new ListUserResponse(raws));
        }
    }
}
