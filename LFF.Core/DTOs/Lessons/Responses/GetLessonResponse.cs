using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Lessons.Responses
{
    public class GetLessonResponse : SuccessResponseBase
    {

        public GetLessonResponse()
          : base()
        {
            this.Messages.Add("Lấy dữ liệu thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public GetLessonResponse(Lesson lesson)
          : this()
        {
            this.Data = new LessonResponse(lesson);
        }
    }
}
