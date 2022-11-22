using LFF.Core.Base;
using LFF.Core.DTOs.StudentTestResults.Requests;
using LFF.Core.DTOs.StudentTestResults.Responses;
using LFF.Core.Entities;
using LFF.Core.Utils.Questions;
using System.Threading.Tasks;

namespace LFF.Core.Services.StudentTestResultServices
{
    public partial class StudentTestResultService
    {

        public virtual async Task<ResponseBase> CreateOrUpdateStudentTestResultAsync(CreateStudentTestResultRequest model)
        {
            var questionRepository = this.aggregateRepository.QuestionRepository;
            var studentTestRepository = this.aggregateRepository.StudentTestRepository;
            var studentTestResultRepository = this.aggregateRepository.StudentTestResultRepository;

            var entity = new StudentTestResult();
            entity.StudentTestId = model.StudentTestId;
            entity.QuestionId = model.QuestionId;
            entity.Result = model.Result;

            //Validation
            // TODO: nhớ kiểm tra xem còn trong thời gian làm bài không?

            if (!await studentTestRepository.CheckStudentTestExistedByIdAsync(model.StudentTestId))
            {
                throw BaseDomainException.BadRequest($"không tồn tại học viên kiểm tra nào với id = {model.StudentTestId}");
            }

            if (!await questionRepository.CheckQuestionExistedByIdAsync(model.QuestionId))
            {
                throw BaseDomainException.BadRequest($"không tồn tại câu hỏi nào với id = {model.QuestionId}");
            }

            if (string.IsNullOrEmpty(model.Result))
            {
                throw BaseDomainException.BadRequest("kết quả không được trống");
            }

            var questionEntity = await this.aggregateRepository.QuestionRepository.GetByIdAsync(model.QuestionId);
            var questionModel = QuestionModelFactory.FromJsonString(questionEntity.Content ?? "");

            if (!questionModel.CheckAnswerIsValid(model.Result))
            {
                throw BaseDomainException.BadRequest($"Không tồn tại câu trả lời {model.Result}");
            }

            //Save
            await studentTestResultRepository.CreateOrUpdateResult(entity);

            //Log

            return await Task.FromResult(new CreateOrUpdateStudentTestResultResponse(entity));
        }
    }
}
