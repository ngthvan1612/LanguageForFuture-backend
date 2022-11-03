using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Classrooms.Responses
{
    public class CreateClassroomResponse : SuccessResponseBase
    {

        public CreateClassroomResponse()
          : base()
        {
            this.Messages.Add("Tạo lớp học thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Created;
        }

        public CreateClassroomResponse(Classroom classroom)
          : this()
        {
            this.Data = new ClassroomResponse(classroom);
        }
    }
}
