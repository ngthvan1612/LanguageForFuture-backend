using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.StudentTestResults.Responses
{
    public class GetStudentTestResultResponse : SuccessResponseBase
    {

        public GetStudentTestResultResponse()
          : base()
        {
            this.Messages.Add("Lấy dữ liệu thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public GetStudentTestResultResponse(StudentTestResult studentTestResult)
          : this()
        {
            this.Data = new StudentTestResultResponse(studentTestResult);
        }
    }
}
