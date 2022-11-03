using LFF.Core.Base;
using LFF.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace LFF.Core.DTOs.StudentTestResults.Responses
{
    public class ListStudentTestResultResponse : SuccessResponseBase
    {

        public ListStudentTestResultResponse()
          : base()
        {
            this.Messages.Add("Lấy dữ liệu thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public ListStudentTestResultResponse(IEnumerable<StudentTestResult> studentTestResults)
          : this()
        {
            this.Data = studentTestResults.Select(u => new StudentTestResultResponse(u));
        }
    }
}
