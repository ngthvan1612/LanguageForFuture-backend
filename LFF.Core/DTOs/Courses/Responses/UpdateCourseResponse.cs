using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Courses.Responses
{
    public class UpdateCourseResponse : SuccessResponseBase
    {

        public UpdateCourseResponse()
          : base()
        {
            this.Messages.Add("Cập nhật khóa học thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public UpdateCourseResponse(Course course)
          : this()
        {
            this.Data = new CourseResponse(course);
        }
    }
}
