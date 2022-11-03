using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.StudentTests.Responses
{
    public class GetStudentTestResponse : SuccessResponseBase
    {

        public GetStudentTestResponse()
          : base()
        {
            this.Messages.Add("Lấy dữ liệu thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public GetStudentTestResponse(StudentTest studentTest)
          : this()
        {
            this.Data = new StudentTestResponse(studentTest);
        }
    }
}
