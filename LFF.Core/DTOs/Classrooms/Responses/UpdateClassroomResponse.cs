using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Classrooms.Responses
{
    public class UpdateClassroomResponse : SuccessResponseBase
    {

        public UpdateClassroomResponse()
          : base()
        {
            this.Messages.Add("Cập nhật lớp học thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public UpdateClassroomResponse(Classroom classroom)
          : this()
        {
            this.Data = new ClassroomResponse(classroom);
        }
    }
}
