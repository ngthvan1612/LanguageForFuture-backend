using LFF.Core.Base;
using LFF.Core.DTOs.Registers.Requests;
using LFF.Core.DTOs.Registers.Responses;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Services.RegisterServices
{
    public partial class RegisterService
    {

        public virtual async Task<ResponseBase> UpdateRegisterByIdAsync(Guid id, UpdateRegisterRequest model)
        {
            var userRepository = this.aggregateRepository.UserRepository;
            var classroomRepository = this.aggregateRepository.ClassroomRepository;
            var registerRepository = this.aggregateRepository.RegisterRepository;

            var entity = await registerRepository.GetRegisterByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy đăng ký nào với Id = {id}");

            //Update
            entity.StudentId = model.StudentId;
            entity.ClassId = model.ClassId;
            entity.RegistrationDate = model.RegistrationDate;

            //Validation
            if (model.RegistrationDate is null)
            {
                throw BaseDomainException.BadRequest("ngày đăng ký không được trống");
            }

            if (!await userRepository.CheckUserExistedByIdAsync(model.StudentId))
            {
                throw BaseDomainException.BadRequest($"không tồn tại người dùng nào với id = {model.StudentId}");
            }

            if (!await classroomRepository.CheckClassroomExistedByIdAsync(model.ClassId))
            {
                throw BaseDomainException.BadRequest($"không tồn tại lớp học nào với id = {model.ClassId}");
            }


            //Save
            await registerRepository.UpdateAsync(entity);

            //Log

            return await Task.FromResult(new UpdateRegisterResponse(entity));
        }
    }
}
