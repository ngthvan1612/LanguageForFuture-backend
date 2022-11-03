using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.StudentTestResults.Responses
{
    public class UpdateStudentTestResultResponse : SuccessResponseBase
    {

        public UpdateStudentTestResultResponse()
          : base()
        {
            this.Messages.Add("Cập nhật kết quả kiểm tra thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public UpdateStudentTestResultResponse(StudentTestResult studentTestResult)
          : this()
        {
            this.Data = new StudentTestResultResponse(studentTestResult);
        }
    }
}
