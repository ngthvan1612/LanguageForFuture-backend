using LFF.Core.Base;
using LFF.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace LFF.Core.DTOs.Courses.Responses
{
    public class ListCourseResponse : SuccessResponseBase
    {

        public ListCourseResponse()
          : base()
        {
            this.Messages.Add("Lấy dữ liệu thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public ListCourseResponse(IEnumerable<Course> courses)
          : this()
        {
            this.Data = courses.Select(u => new CourseResponse(u));
        }
    }
}
