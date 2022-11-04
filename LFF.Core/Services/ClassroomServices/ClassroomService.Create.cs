using LFF.Core.Base;
using LFF.Core.DTOs.Classrooms.Requests;
using LFF.Core.DTOs.Classrooms.Responses;
using LFF.Core.Entities;
using System.Threading.Tasks;

namespace LFF.Core.Services.ClassroomServices
{
    public partial class ClassroomService
    {

        public virtual async Task<ResponseBase> CreateClassroomAsync(CreateClassroomRequest model)
        {
            var userRepository = this.aggregateRepository.UserRepository;
            var courseRepository = this.aggregateRepository.CourseRepository;
            var classroomRepository = this.aggregateRepository.ClassroomRepository;

            var entity = new Classroom();
            entity.Name = model.Name;
            entity.StartDate = model.StartDate;
            entity.NumberOfLessons = model.NumberOfLessons;
            entity.CourseId = model.CourseId;
            entity.TeacherId = model.TeacherId;

            //Validation
            if (string.IsNullOrEmpty(model.Name))
            {
                throw BaseDomainException.BadRequest("tên lớp không được trống");
            }

            if (model.StartDate is null)
            {
                throw BaseDomainException.BadRequest("ngày bắt đầu học không được trống");
            }

            if (model.NumberOfLessons is null)
            {
                throw BaseDomainException.BadRequest("số buổi học không được trống");
            }

            if (!await userRepository.CheckUserExistedByIdAsync(model.TeacherId))
            {
                throw BaseDomainException.BadRequest($"không tồn tại người dùng nào với id = {model.TeacherId}");
            }

            if (!await courseRepository.CheckCourseExistedByIdAsync(model.CourseId))
            {
                throw BaseDomainException.BadRequest($"không tồn tại khóa học nào với id = {model.CourseId}");
            }

            if (await classroomRepository.CheckClassroomExistedByNameAsync(model.Name))
            {
                throw BaseDomainException.BadRequest($"tên lớp '{model.Name}' đã tồn tại trên hệ thống");
            }

            var user = await userRepository.GetUserByIdAsync(model.TeacherId);

            if (user.Role != UserRoles.Teacher)
                throw BaseDomainException.BadRequest("Chỉ có giáo viên mới có thể nhận lớp");

            //Save
            await classroomRepository.CreateAsync(entity);

            //Log

            return await Task.FromResult(new CreateClassroomResponse(entity));
        }
    }
}
