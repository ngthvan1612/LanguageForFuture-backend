using LFF.Core.Base;
using LFF.Core.DTOs.Lessons.Requests;
using LFF.Core.DTOs.Lessons.Responses;
using LFF.Core.Entities;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Services.LessonServices
{
    public partial class LessonService : ILessonService
    {
        public async Task<ResponseBase> UpdateApprovalByIdAsync(UpdateLessonApprovalRequest request)
        {
            var lessonEntity = await this.aggregateRepository.LessonRepository.GetByIdAsync(request.LessonId);

            if (lessonEntity is null)
                throw BaseDomainException.NotFound($"Không tìm thấy buổi học nào với id = {request.LessonId}");

            Lesson entity = new Lesson();

            if (request.Reason != null)
                request.Reason = request.Reason.Trim().Trim('\n', '\r', ' ', '\t');

            if (request.IsApproved == false && (string.IsNullOrEmpty(request.Reason)))
                throw BaseDomainException.BadRequest($"Khi không duyệt bài học phải có lý do không duyệt");

            entity.Id = request.LessonId;
            entity.IsApproved = request.IsApproved;
            entity.ReasonForNotApproving = request.Reason;

            await this.aggregateRepository.LessonRepository.UpdateApprovalAsync(entity);

            return SuccessResponseBase.Send("Cập nhật thông tin buổi học thành công");
        }

        public virtual async Task<ResponseBase> UpdateLessonByIdAsync(Guid id, UpdateLessonRequest model)
        {
            var classroomRepository = this.aggregateRepository.ClassroomRepository;
            var lessonRepository = this.aggregateRepository.LessonRepository;

            var entity = await lessonRepository.GetLessonByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy buổi học nào với Id = {id}");

            //Update
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.StartTime = model.StartTime;
            entity.EndTime = model.EndTime;
            entity.ClassId = model.ClassId;

            //Validation
            if (string.IsNullOrEmpty(model.Name))
            {
                throw BaseDomainException.BadRequest("tên buổi học không được trống");
            }

            if (string.IsNullOrEmpty(model.Description))
            {
                throw BaseDomainException.BadRequest("mô tả không được trống");
            }

            if (model.StartTime is null)
            {
                throw BaseDomainException.BadRequest("ngày giờ bắt đầu buổi học không được trống");
            }

            if (model.EndTime is null)
            {
                throw BaseDomainException.BadRequest("ngày giờ kết thúc buổi học không được trống");
            }

            if (!await classroomRepository.CheckClassroomExistedByIdAsync(model.ClassId))
            {
                throw BaseDomainException.BadRequest($"không tồn tại lớp học nào với id = {model.ClassId}");
            }


            //Save
            await lessonRepository.UpdateAsync(entity);

            //Log

            return await Task.FromResult(new UpdateLessonResponse(entity));
        }

        public async Task<ResponseBase> UpdateLessonContentByLessonIdAsync(Guid lessonId, UpdateLessonContentRequest request)
        {
            if (!(await this.aggregateRepository.LessonRepository.CheckLessonExistedByIdAsync(lessonId)))
            {
                throw BaseDomainException.BadRequest($"Không tồn tại lớp học nào với mã lớp {lessonId}");
            }

            if (string.IsNullOrEmpty(request.LessonContent))
            {
                throw BaseDomainException.BadRequest($"Nội dung không được trống");
            }

            var model = new Lesson()
            {
                Id = lessonId,
                LessonContent = request.LessonContent
            };

            await this.aggregateRepository.LessonRepository.UpdateLessonContentByLessonIdAsync(model);

            return await Task.FromResult(new UpdateLessonContentResponse());
        }
    }
}
