using LFF.Core.Base;
using LFF.Core.DTOs.Lessons.Requests;
using LFF.Core.DTOs.Lessons.Responses;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Services.LessonServices
{
    public partial class LessonService
    {

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
    }
}
