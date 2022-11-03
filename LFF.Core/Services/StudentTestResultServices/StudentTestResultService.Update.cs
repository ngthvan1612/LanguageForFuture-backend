using LFF.Core.Base;
using LFF.Core.DTOs.StudentTestResults.Requests;
using LFF.Core.DTOs.StudentTestResults.Responses;
using System;
using System.Threading.Tasks;

namespace LFF.Core.Services.StudentTestResultServices
{
    public partial class StudentTestResultService
    {

        public virtual async Task<ResponseBase> UpdateStudentTestResultByIdAsync(Guid id, UpdateStudentTestResultRequest model)
        {
            var questionRepository = this.aggregateRepository.QuestionRepository;
            var studentTestRepository = this.aggregateRepository.StudentTestRepository;
            var studentTestResultRepository = this.aggregateRepository.StudentTestResultRepository;

            var entity = await studentTestResultRepository.GetStudentTestResultByIdAsync(id);

            if (entity == null)
                throw BaseDomainException.NotFound($"Không tìm thấy kết quả kiểm tra nào với Id = {id}");

            //Update
            entity.StudentTestId = model.StudentTestId;
            entity.QuestionId = model.QuestionId;
            entity.Result = model.Result;

            //Validation
            if (string.IsNullOrEmpty(model.Result))
            {
                throw BaseDomainException.BadRequest("kết quả không được trống");
            }

            if (!await studentTestRepository.CheckStudentTestExistedByIdAsync(model.StudentTestId))
            {
                throw BaseDomainException.BadRequest($"không tồn tại học viên kiểm tra nào với id = {model.StudentTestId}");
            }

            if (!await questionRepository.CheckQuestionExistedByIdAsync(model.QuestionId))
            {
                throw BaseDomainException.BadRequest($"không tồn tại câu hỏi nào với id = {model.QuestionId}");
            }


            //Save
            await studentTestResultRepository.UpdateAsync(entity);

            //Log

            return await Task.FromResult(new UpdateStudentTestResultResponse(entity));
        }
    }
}
