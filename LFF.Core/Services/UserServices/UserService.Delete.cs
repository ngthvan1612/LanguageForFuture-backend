using LFF.Core.Base;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Services.UserServices
{
    public partial class UserService
    {

        public virtual async Task<ResponseBase> DeleteUserByIdAsync(Guid id)
        {
            var userRepository = this.aggregateRepository.UserRepository;

            var entity = await userRepository.GetUserByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy người dùng nào với Id = {id}");

            //Kiểm tra nếu xóa thì có va chạm những entity khác?

            //Xóa
            await userRepository.DeleteAsync(entity);

            return await Task.FromResult(SuccessResponseBase.Send("Xóa người dùng thành công"));
        }
    }
}
