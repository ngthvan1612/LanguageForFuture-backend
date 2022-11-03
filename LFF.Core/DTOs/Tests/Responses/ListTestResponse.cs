using LFF.Core.Base;
using LFF.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace LFF.Core.DTOs.Tests.Responses
{
    public class ListTestResponse : SuccessResponseBase
    {

        public ListTestResponse()
          : base()
        {
            this.Messages.Add("Lấy dữ liệu thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public ListTestResponse(IEnumerable<Test> tests)
          : this()
        {
            this.Data = tests.Select(u => new TestResponse(u));
        }
    }
}
