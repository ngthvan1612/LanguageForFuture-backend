using LFF.Core.Base;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Services.RegisterServices
{
    public partial class RegisterService
    {

        public virtual async Task<ResponseBase> DeleteRegisterByIdAsync(Guid id)
        {
            var registerRepository = this.aggregateRepository.RegisterRepository;

            var entity = await registerRepository.GetRegisterByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy đăng ký nào với Id = {id}");

            //Kiểm tra nếu xóa thì có va chạm những entity khác?

            //Xóa
            await registerRepository.DeleteAsync(entity);

            return await Task.FromResult(SuccessResponseBase.Send("Xóa đăng ký thành công"));
        }
    }
}
