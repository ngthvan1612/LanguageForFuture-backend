using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.StudentTests.Responses
{
    public class CreateStudentTestResponse : SuccessResponseBase
    {

        public CreateStudentTestResponse()
          : base()
        {
            this.Messages.Add("Tạo học viên kiểm tra thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Created;
        }

        public CreateStudentTestResponse(StudentTest studentTest)
          : this()
        {
            this.Data = new StudentTestResponse(studentTest);
        }
    }
}
