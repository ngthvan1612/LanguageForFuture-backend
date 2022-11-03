using LFF.Core.Base;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Services.LessonServices
{
    public partial class LessonService
    {

        public virtual async Task<ResponseBase> DeleteLessonByIdAsync(Guid id)
        {
            var lessonRepository = this.aggregateRepository.LessonRepository;

            var entity = await lessonRepository.GetLessonByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy buổi học nào với Id = {id}");

            //Kiểm tra nếu xóa thì có va chạm những entity khác?

            //Xóa
            await lessonRepository.DeleteAsync(entity);

            return await Task.FromResult(SuccessResponseBase.Send("Xóa buổi học thành công"));
        }
    }
}
