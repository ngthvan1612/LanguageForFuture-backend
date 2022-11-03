using LFF.Core.Base;
using LFF.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace LFF.Core.DTOs.Classrooms.Responses
{
    public class ListClassroomResponse : SuccessResponseBase
    {

        public ListClassroomResponse()
          : base()
        {
            this.Messages.Add("Lấy dữ liệu thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public ListClassroomResponse(IEnumerable<Classroom> classrooms)
          : this()
        {
            this.Data = classrooms.Select(u => new ClassroomResponse(u));
        }
    }
}
