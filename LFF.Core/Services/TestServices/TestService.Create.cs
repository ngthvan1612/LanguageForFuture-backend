using LFF.Core.Base;
using LFF.Core.DTOs.Tests.Requests;
using LFF.Core.DTOs.Tests.Responses;
using LFF.Core.Entities;
using System.Threading.Tasks;

namespace LFF.Core.Services.TestServices
{
    public partial class TestService
    {

        public virtual async Task<ResponseBase> CreateTestAsync(CreateTestRequest model)
        {
            var lessonRepository = this.aggregateRepository.LessonRepository;
            var testRepository = this.aggregateRepository.TestRepository;

            var entity = new Test();
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.StartDate = model.StartDate;
            entity.EndDate = model.EndDate;
            entity.NumberOfAttempts = model.NumberOfAttempts;
            entity.Time = model.Time;
            entity.LessonId = model.LessonId;

            //Validation
            if (string.IsNullOrEmpty(model.Name))
            {
                throw BaseDomainException.BadRequest("tên bài kiểm tra không được trống");
            }

            if (string.IsNullOrEmpty(model.Description))
            {
                throw BaseDomainException.BadRequest("mô tả không được trống");
            }

            if (model.StartDate is null)
            {
                throw BaseDomainException.BadRequest("ngày bắt đầu không được trống");
            }

            if (model.EndDate is null)
            {
                throw BaseDomainException.BadRequest("ngày kết thúc không được trống");
            }

            if (model.NumberOfAttempts is null)
            {
                throw BaseDomainException.BadRequest("số lần kiểm tra tối đa không được trống");
            }

            if (model.Time is null)
            {
                throw BaseDomainException.BadRequest("thời gian làm bài không được trống");
            }

            if (!await lessonRepository.CheckLessonExistedByIdAsync(model.LessonId))
            {
                throw BaseDomainException.BadRequest($"không tồn tại buổi học nào với id = {model.LessonId}");
            }


            //Save
            await testRepository.CreateAsync(entity);

            //Log

            return await Task.FromResult(new CreateTestResponse(entity));
        }
    }
}
