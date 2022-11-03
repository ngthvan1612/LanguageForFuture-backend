using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.StudentTests.Responses
{
    public class UpdateStudentTestResponse : SuccessResponseBase
    {

        public UpdateStudentTestResponse()
          : base()
        {
            this.Messages.Add("Cập nhật học viên kiểm tra thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public UpdateStudentTestResponse(StudentTest studentTest)
          : this()
        {
            this.Data = new StudentTestResponse(studentTest);
        }
    }
}
