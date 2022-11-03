using LFF.Core.Base;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Services.StudentTestServices
{
    public partial class StudentTestService
    {

        public virtual async Task<ResponseBase> DeleteStudentTestByIdAsync(Guid id)
        {
            var studentTestRepository = this.aggregateRepository.StudentTestRepository;

            var entity = await studentTestRepository.GetStudentTestByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy học viên kiểm tra nào với Id = {id}");

            //Kiểm tra nếu xóa thì có va chạm những entity khác?

            //Xóa
            await studentTestRepository.DeleteAsync(entity);

            return await Task.FromResult(SuccessResponseBase.Send("Xóa học viên kiểm tra thành công"));
        }
    }
}
