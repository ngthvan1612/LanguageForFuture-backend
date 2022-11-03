using LFF.Core.Base;
using LFF.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace LFF.Core.DTOs.Lessons.Responses
{
    public class ListLessonResponse : SuccessResponseBase
    {

        public ListLessonResponse()
          : base()
        {
            this.Messages.Add("Lấy dữ liệu thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public ListLessonResponse(IEnumerable<Lesson> lessons)
          : this()
        {
            this.Data = lessons.Select(u => new LessonResponse(u));
        }
    }
}
