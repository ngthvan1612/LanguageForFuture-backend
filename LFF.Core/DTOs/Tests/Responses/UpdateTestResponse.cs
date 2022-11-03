using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Tests.Responses
{
    public class UpdateTestResponse : SuccessResponseBase
    {

        public UpdateTestResponse()
          : base()
        {
            this.Messages.Add("Cập nhật bài kiểm tra thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public UpdateTestResponse(Test test)
          : this()
        {
            this.Data = new TestResponse(test);
        }
    }
}
