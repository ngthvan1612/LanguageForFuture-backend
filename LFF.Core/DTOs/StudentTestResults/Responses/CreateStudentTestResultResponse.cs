using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.StudentTestResults.Responses
{
    public class CreateStudentTestResultResponse : SuccessResponseBase
    {

        public CreateStudentTestResultResponse()
          : base()
        {
            this.Messages.Add("Tạo kết quả kiểm tra thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Created;
        }

        public CreateStudentTestResultResponse(StudentTestResult studentTestResult)
          : this()
        {
            this.Data = new StudentTestResultResponse(studentTestResult);
        }
    }
}
