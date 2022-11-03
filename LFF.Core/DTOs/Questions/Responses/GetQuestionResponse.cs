using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Questions.Responses
{
    public class GetQuestionResponse : SuccessResponseBase
    {

        public GetQuestionResponse()
          : base()
        {
            this.Messages.Add("Lấy dữ liệu thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public GetQuestionResponse(Question question)
          : this()
        {
            this.Data = new QuestionResponse(question);
        }
    }
}
