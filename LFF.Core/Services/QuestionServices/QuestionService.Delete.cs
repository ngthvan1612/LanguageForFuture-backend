using LFF.Core.Base;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Services.QuestionServices
{
    public partial class QuestionService
    {

        public virtual async Task<ResponseBase> DeleteQuestionByIdAsync(Guid id)
        {
            var questionRepository = this.aggregateRepository.QuestionRepository;

            var entity = await questionRepository.GetQuestionByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy câu hỏi nào với Id = {id}");

            //Kiểm tra nếu xóa thì có va chạm những entity khác?

            //Xóa
            await questionRepository.DeleteAsync(entity);

            return await Task.FromResult(SuccessResponseBase.Send("Xóa câu hỏi thành công"));
        }
    }
}
