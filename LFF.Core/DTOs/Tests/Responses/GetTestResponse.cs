using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Tests.Responses
{
    public class GetTestResponse : SuccessResponseBase
    {

        public GetTestResponse()
          : base()
        {
            this.Messages.Add("Lấy dữ liệu thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public GetTestResponse(Test test)
          : this()
        {
            this.Data = new TestResponse(test);
        }
    }
}
