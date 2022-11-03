using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Questions.Responses
{
    public class CreateQuestionResponse : SuccessResponseBase
    {

        public CreateQuestionResponse()
          : base()
        {
            this.Messages.Add("Tạo câu hỏi thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Created;
        }

        public CreateQuestionResponse(Question question)
          : this()
        {
            this.Data = new QuestionResponse(question);
        }
    }
}
