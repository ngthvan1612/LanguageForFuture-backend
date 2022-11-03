using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Questions.Responses
{
    public class UpdateQuestionResponse : SuccessResponseBase
    {

        public UpdateQuestionResponse()
          : base()
        {
            this.Messages.Add("Cập nhật câu hỏi thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public UpdateQuestionResponse(Question question)
          : this()
        {
            this.Data = new QuestionResponse(question);
        }
    }
}
