using LFF.Core.Base;
using LFF.Core.DTOs.Users.Requests;
using LFF.Core.DTOs.Users.Responses;
using LFF.Core.Entities;
using System.Threading.Tasks;

namespace LFF.Core.Services.UserServices
{
    public partial class UserService
    {

        public virtual async Task<ResponseBase> CreateUserAsync(CreateUserRequest model)
        {
            var userRepository = this.aggregateRepository.UserRepository;

            var entity = new User();
            entity.Username = model.Username;
            entity.Password = model.Password;
            entity.FullName = model.FullName;
            entity.Email = model.Email;
            entity.DateOfBirth = model.DateOfBirth;
            entity.CMND = model.CMND;
            entity.Role = model.Role;

            //Validation
            if (string.IsNullOrEmpty(model.Username))
            {
                throw BaseDomainException.BadRequest("tên người dùng không được trống");
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                throw BaseDomainException.BadRequest("mật khẩu không được trống");
            }

            if (string.IsNullOrEmpty(model.FullName))
            {
                throw BaseDomainException.BadRequest("tên đầy đủ không được trống");
            }

            if (string.IsNullOrEmpty(model.Email))
            {
                throw BaseDomainException.BadRequest("email không được trống");
            }

            if (model.DateOfBirth is null)
            {
                throw BaseDomainException.BadRequest("ngày sinh không được trống");
            }

            if (string.IsNullOrEmpty(model.CMND))
            {
                throw BaseDomainException.BadRequest("Chứng minh nhân dân không được trống");
            }

            if (string.IsNullOrEmpty(model.Role))
            {
                throw BaseDomainException.BadRequest("quyền không được trống");
            }

            if (await userRepository.CheckUserExistedByUsernameAsync(model.Username))
            {
                throw BaseDomainException.BadRequest($"tên người dùng '{model.Username}' đã tồn tại trên hệ thống");
            }
            if (await userRepository.CheckUserExistedByEmailAsync(model.Email))
            {
                throw BaseDomainException.BadRequest($"email '{model.Email}' đã tồn tại trên hệ thống");
            }
            if (await userRepository.CheckUserExistedByCMNDAsync(model.CMND))
            {
                throw BaseDomainException.BadRequest($"Chứng minh nhân dân '{model.CMND}' đã tồn tại trên hệ thống");
            }

            //Save
            await userRepository.CreateAsync(entity);

            //Log

            return await Task.FromResult(new CreateUserResponse(entity));
        }
    }
}
