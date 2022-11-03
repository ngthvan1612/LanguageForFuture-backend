using LFF.Core.Base;
using LFF.Core.DTOs.Questions.Requests;
using LFF.Core.DTOs.Questions.Responses;
using LFF.Core.Entities;
using System.Threading.Tasks;

namespace LFF.Core.Services.QuestionServices
{
    public partial class QuestionService
    {

        public virtual async Task<ResponseBase> CreateQuestionAsync(CreateQuestionRequest model)
        {
            var testRepository = this.aggregateRepository.TestRepository;
            var questionRepository = this.aggregateRepository.QuestionRepository;

            var entity = new Question();
            entity.Content = model.Content;
            entity.QuestionType = model.QuestionType;
            entity.TestId = model.TestId;

            //Validation
            if (string.IsNullOrEmpty(model.Content))
            {
                throw BaseDomainException.BadRequest("nội dung câu hỏi không được trống");
            }

            if (string.IsNullOrEmpty(model.QuestionType))
            {
                throw BaseDomainException.BadRequest("loại câu hỏi không được trống");
            }

            if (!await testRepository.CheckTestExistedByIdAsync(model.TestId))
            {
                throw BaseDomainException.BadRequest($"không tồn tại bài kiểm tra nào với id = {model.TestId}");
            }


            //Save
            await questionRepository.CreateAsync(entity);

            //Log

            return await Task.FromResult(new CreateQuestionResponse(entity));
        }
    }
}
