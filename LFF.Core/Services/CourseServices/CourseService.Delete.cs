using LFF.Core.Base;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Services.CourseServices
{
    public partial class CourseService
    {

        public virtual async Task<ResponseBase> DeleteCourseByIdAsync(Guid id)
        {
            var courseRepository = this.aggregateRepository.CourseRepository;

            var entity = await courseRepository.GetCourseByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy khóa học nào với Id = {id}");

            //Kiểm tra nếu xóa thì có va chạm những entity khác?

            //Xóa
            await courseRepository.DeleteAsync(entity);

            return await Task.FromResult(SuccessResponseBase.Send("Xóa khóa học thành công"));
        }
    }
}
