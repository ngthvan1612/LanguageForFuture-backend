using LFF.Core.Base;
using LFF.Core.DTOs.Courses.Requests;
using LFF.Core.DTOs.Courses.Responses;
using LFF.Core.Entities;
using System.Threading.Tasks;

namespace LFF.Core.Services.CourseServices
{
    public partial class CourseService
    {

        public virtual async Task<ResponseBase> CreateCourseAsync(CreateCourseRequest model)
        {
            var courseRepository = this.aggregateRepository.CourseRepository;

            var entity = new Course();
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

            if (await courseRepository.CheckCourseExistedByNameAsync(model.Name))
            {
                throw BaseDomainException.BadRequest($"tên khóa học '{model.Name}' đã tồn tại trên hệ thống");
            }

            //Save
            await courseRepository.CreateAsync(entity);

            //Log

            return await Task.FromResult(new CreateCourseResponse(entity));
        }
    }
}
