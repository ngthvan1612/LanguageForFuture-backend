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

        public virtual async Task<ResponseBase> CreateStudentTestAsync(CreateStudentTestRequest model)
        {
            var userRepository = this.aggregateRepository.UserRepository;
            var testRepository = this.aggregateRepository.TestRepository;
            var studentTestRepository = this.aggregateRepository.StudentTestRepository;

            var entity = new StudentTest();
            entity.StudentId = model.StudentId;
            entity.TestId = model.TestId;
            entity.StartDate = DateTime.Now;

            //Validation: sắp xếp theo độ ưu tiên người dùng

            //Validate dữ liệu
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

            //Validate có đang kiểm tra gì không?
            if (await this.aggregateRepository.TestRepository.IsDoingAnyTest(model.StudentId))
                throw BaseDomainException.BadRequest("Bạn đang có một bài kiểm tra chưa hoàn tất");

            //Validate thời gian làm bài
            var currentDateTime = DateTime.Now;
            var currentTest = await testRepository.GetByIdAsync(model.TestId);

            if (currentDateTime < currentTest.StartDate || currentTest.EndDate < currentDateTime)
                throw BaseDomainException.BadRequest("Hiện tại không trong thời gian được phép làm bài kiểm tra");

            //Validate số lần làm bài
            if (currentTest.NumberOfAttempts >= 0)
            {
                int numberOfTimes = await this.aggregateRepository.TestRepository.NumberOfTimesAttemptTest(model.StudentId, model.TestId);
                if (numberOfTimes + 1 > currentTest.NumberOfAttempts)
                    throw BaseDomainException.BadRequest($"Bài kiểm tra này chỉ có thể làm tối đa {currentTest.NumberOfAttempts} lần");
            }

            //Save
            await studentTestRepository.CreateAsync(entity);

            //Log

            return await Task.FromResult(new CreateStudentTestResponse(entity));
        }
    }
}
