using LFF.Core.Base;
using LFF.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace LFF.Core.DTOs.StudentTests.Responses
{
    public class ListStudentTestResponse : SuccessResponseBase
    {

        public ListStudentTestResponse()
          : base()
        {
            this.Messages.Add("Lấy dữ liệu thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public ListStudentTestResponse(IEnumerable<StudentTest> studentTests)
          : this()
        {
            this.Data = studentTests.Select(u => new StudentTestResponse(u));
        }
    }
}
