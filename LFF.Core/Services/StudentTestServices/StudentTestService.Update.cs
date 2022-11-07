using LFF.Core.Base;
using LFF.Core.DTOs.StudentTests.Requests;
using LFF.Core.DTOs.StudentTests.Responses;
using LFF.Core.Entities;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Services.StudentTestServices
{
    public partial class StudentTestService
    {

        public virtual async Task<ResponseBase> UpdateStudentTestByIdAsync(Guid id, UpdateStudentTestRequest model)
        {
            var userRepository = this.aggregateRepository.UserRepository;
            var testRepository = this.aggregateRepository.TestRepository;
            var studentTestRepository = this.aggregateRepository.StudentTestRepository;

            var entity = await studentTestRepository.GetStudentTestByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy học viên kiểm tra nào với Id = {id}");

            //Update
            entity.StudentId = model.StudentId;
            entity.TestId = model.TestId;

            //Validation

            if (!await userRepository.CheckUserExistedByIdAsync(model.StudentId))
            {
                throw BaseDomainException.BadRequest($"không tồn tại người dùng nào với id = {model.StudentId}");
            }

            if (!await testRepository.CheckTestExistedByIdAsync(model.TestId))
            {
                throw BaseDomainException.BadRequest($"không tồn tại bài kiểm tra nào với id = {model.TestId}");
            }

            if ((await userRepository.GetUserByIdAsync(model.StudentId)).Role != UserRoles.Student)
            {
                throw BaseDomainException.BadRequest("Chỉ có học viên mới có thể làm bài kiểm tra");
            }

            //Save
            await studentTestRepository.UpdateAsync(entity);

            //Log

            return await Task.FromResult(new UpdateStudentTestResponse(entity));
        }
    }
}
