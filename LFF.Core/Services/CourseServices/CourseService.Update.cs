using LFF.Core.Base;
using LFF.Core.DTOs.Courses.Requests;
using LFF.Core.DTOs.Courses.Responses;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Services.CourseServices
{
    public partial class CourseService
    {

        public virtual async Task<ResponseBase> UpdateCourseByIdAsync(Guid id, UpdateCourseRequest model)
        {
            var courseRepository = this.aggregateRepository.CourseRepository;

            var entity = await courseRepository.GetCourseByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy khóa học nào với Id = {id}");

            //Update
            entity.Name = model.Name;
            entity.Description = model.Description;

            //Validation
            if (string.IsNullOrEmpty(model.Name))
            {
                throw BaseDomainException.BadRequest("tên khóa học không được trống");
            }

            if (string.IsNullOrEmpty(model.Description))
            {
                throw BaseDomainException.BadRequest("mô tả không được trống");
            }

            if (await courseRepository.CheckCourseExistedByNameExceptIdAsync(id, model.Name))
            {
                throw BaseDomainException.BadRequest($"tên khóa học '{model.Name}' đã tồn tại trên hệ thống");
            }


            //Save
            await courseRepository.UpdateAsync(entity);

            //Log

            return await Task.FromResult(new UpdateCourseResponse(entity));
        }
    }
}
