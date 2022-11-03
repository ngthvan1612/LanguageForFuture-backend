using LFF.Core.Base;
using LFF.Core.DTOs.Lectures.Requests;
using LFF.Core.DTOs.Lectures.Responses;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Services.LectureServices
{
    public partial class LectureService
    {

        public virtual async Task<ResponseBase> UpdateLectureByIdAsync(Guid id, UpdateLectureRequest model)
        {
            var lessonRepository = this.aggregateRepository.LessonRepository;
            var lectureRepository = this.aggregateRepository.LectureRepository;

            var entity = await lectureRepository.GetLectureByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy bài giảng nào với Id = {id}");

            //Update
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.Content = model.Content;
            entity.LessonId = model.LessonId;

            //Validation
            if (string.IsNullOrEmpty(model.Name))
            {
                throw BaseDomainException.BadRequest("tên bài giảng không được trống");
            }

            if (string.IsNullOrEmpty(model.Description))
            {
                throw BaseDomainException.BadRequest("mô tả không được trống");
            }

            if (string.IsNullOrEmpty(model.Content))
            {
                throw BaseDomainException.BadRequest("nội dung không được trống");
            }

            if (!await lessonRepository.CheckLessonExistedByIdAsync(model.LessonId))
            {
                throw BaseDomainException.BadRequest($"không tồn tại buổi học nào với id = {model.LessonId}");
            }


            //Save
            await lectureRepository.UpdateAsync(entity);

            //Log

            return await Task.FromResult(new UpdateLectureResponse(entity));
        }
    }
}
