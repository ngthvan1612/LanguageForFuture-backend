using LFF.Core.Base;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Services.LectureServices
{
    public partial class LectureService
    {

        public virtual async Task<ResponseBase> DeleteLectureByIdAsync(Guid id)
        {
            var lectureRepository = this.aggregateRepository.LectureRepository;

            var entity = await lectureRepository.GetLectureByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy bài giảng nào với Id = {id}");

            //Kiểm tra nếu xóa thì có va chạm những entity khác?

            //Xóa
            await lectureRepository.DeleteAsync(entity);

            return await Task.FromResult(SuccessResponseBase.Send("Xóa bài giảng thành công"));
        }
    }
}
