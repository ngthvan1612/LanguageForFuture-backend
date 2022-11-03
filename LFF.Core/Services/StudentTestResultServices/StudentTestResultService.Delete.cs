using LFF.Core.Base;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Services.StudentTestResultServices
{
    public partial class StudentTestResultService
    {

        public virtual async Task<ResponseBase> DeleteStudentTestResultByIdAsync(Guid id)
        {
            var studentTestResultRepository = this.aggregateRepository.StudentTestResultRepository;

            var entity = await studentTestResultRepository.GetStudentTestResultByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy kết quả kiểm tra nào với Id = {id}");

            //Kiểm tra nếu xóa thì có va chạm những entity khác?

            //Xóa
            await studentTestResultRepository.DeleteAsync(entity);

            return await Task.FromResult(SuccessResponseBase.Send("Xóa kết quả kiểm tra thành công"));
        }
    }
}
