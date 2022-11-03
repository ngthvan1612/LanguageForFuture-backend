using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Lessons.Responses
{
    public class UpdateLessonResponse : SuccessResponseBase
    {

        public UpdateLessonResponse()
          : base()
        {
            this.Messages.Add("Cập nhật buổi học thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public UpdateLessonResponse(Lesson lesson)
          : this()
        {
            this.Data = new LessonResponse(lesson);
        }
    }
}
