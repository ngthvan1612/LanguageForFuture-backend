using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Courses.Responses
{
    public class CreateCourseResponse : SuccessResponseBase
    {

        public CreateCourseResponse()
          : base()
        {
            this.Messages.Add("Tạo khóa học thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Created;
        }

        public CreateCourseResponse(Course course)
          : this()
        {
            this.Data = new CourseResponse(course);
        }
    }
}
