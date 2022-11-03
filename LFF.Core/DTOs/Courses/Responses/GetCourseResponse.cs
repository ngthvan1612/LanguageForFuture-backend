using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Courses.Responses
{
    public class GetCourseResponse : SuccessResponseBase
    {

        public GetCourseResponse()
          : base()
        {
            this.Messages.Add("Lấy dữ liệu thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public GetCourseResponse(Course course)
          : this()
        {
            this.Data = new CourseResponse(course);
        }
    }
}
