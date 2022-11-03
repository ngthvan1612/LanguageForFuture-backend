using LFF.Core.Base;
using LFF.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace LFF.Core.DTOs.Questions.Responses
{
    public class ListQuestionResponse : SuccessResponseBase
    {

        public ListQuestionResponse()
          : base()
        {
            this.Messages.Add("Lấy dữ liệu thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public ListQuestionResponse(IEnumerable<Question> questions)
          : this()
        {
            this.Data = questions.Select(u => new QuestionResponse(u));
        }
    }
}
