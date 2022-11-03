using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Tests.Responses
{
    public class CreateTestResponse : SuccessResponseBase
    {

        public CreateTestResponse()
          : base()
        {
            this.Messages.Add("Tạo bài kiểm tra thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Created;
        }

        public CreateTestResponse(Test test)
          : this()
        {
            this.Data = new TestResponse(test);
        }
    }
}
