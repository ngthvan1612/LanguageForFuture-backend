using LFF.Core.Base;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Services.TestServices
{
    public partial class TestService
    {

        public virtual async Task<ResponseBase> DeleteTestByIdAsync(Guid id)
        {
            var testRepository = this.aggregateRepository.TestRepository;

            var entity = await testRepository.GetTestByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy bài kiểm tra nào với Id = {id}");

            //Kiểm tra nếu xóa thì có va chạm những entity khác?

            //Xóa
            await testRepository.DeleteAsync(entity);

            return await Task.FromResult(SuccessResponseBase.Send("Xóa bài kiểm tra thành công"));
        }
    }
}
