using LFF.Core.Base;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Services.ClassroomServices
{
    public partial class ClassroomService
    {

        public virtual async Task<ResponseBase> DeleteClassroomByIdAsync(Guid id)
        {
            var classroomRepository = this.aggregateRepository.ClassroomRepository;

            var entity = await classroomRepository.GetClassroomByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy lớp học nào với Id = {id}");

            //Kiểm tra nếu xóa thì có va chạm những entity khác?

            //Xóa
            await classroomRepository.DeleteAsync(entity);

            return await Task.FromResult(SuccessResponseBase.Send("Xóa lớp học thành công"));
        }
    }
}
