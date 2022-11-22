using LFF.Core.Base;
using LFF.Core.DTOs.Questions.Requests;
using LFF.Core.DTOs.Questions.Responses;
using LFF.Core.Utils.Questions;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Services.QuestionServices
{
    public partial class QuestionService
    {

        public virtual async Task<ResponseBase> UpdateQuestionByIdAsync(Guid id, UpdateQuestionRequest model)
        {
            var testRepository = this.aggregateRepository.TestRepository;
            var questionRepository = this.aggregateRepository.QuestionRepository;

            var entity = await questionRepository.GetQuestionByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy câu hỏi nào với Id = {id}");

            //Update
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

            var questionContentModel = QuestionModelFactory.FromJsonString(model.Content);
            questionContentModel.RunValidation();
            entity.Content = QuestionModelFactory.ToJsonString(questionContentModel);

            //Save
            await questionRepository.UpdateAsync(entity);

            //Log

            return await Task.FromResult(new UpdateQuestionResponse(entity));
        }
    }
}
