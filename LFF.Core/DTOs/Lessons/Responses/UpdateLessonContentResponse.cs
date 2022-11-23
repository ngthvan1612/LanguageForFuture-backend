using LFF.Core.Base;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LFF.Core.DTOs.Lessons.Responses
{
    public class UpdateLessonContentResponse : SuccessResponseBase
    {
        public UpdateLessonContentResponse()
            : base()
        {
            this.Messages.Add("Cập nhật bài giảng thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Created;
        }
    }
}
