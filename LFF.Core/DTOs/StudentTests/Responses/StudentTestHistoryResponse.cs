using LFF.Core.Base;
using LFF.Core.Entities.Supports;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LFF.Core.DTOs.StudentTests.Responses
{
    public class StudentTestHistoryResponse : SuccessResponseBase
    {

        public StudentTestHistoryResponse()
          : base()
        {
            this.Messages.Add("Lấy dữ liệu thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public StudentTestHistoryResponse(StudentTestHistory studentTest)
          : this()
        {
            this.Data = studentTest;
        }
    }
}
