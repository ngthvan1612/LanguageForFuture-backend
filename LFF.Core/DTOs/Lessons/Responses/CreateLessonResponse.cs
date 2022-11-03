using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Lessons.Responses
{
    public class CreateLessonResponse : SuccessResponseBase
    {

        public CreateLessonResponse()
          : base()
        {
            this.Messages.Add("Tạo buổi học thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Created;
        }

        public CreateLessonResponse(Lesson lesson)
          : this()
        {
            this.Data = new LessonResponse(lesson);
        }
    }
}
