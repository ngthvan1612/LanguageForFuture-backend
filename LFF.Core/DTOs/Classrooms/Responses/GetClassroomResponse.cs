using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Classrooms.Responses
{
    public class GetClassroomResponse : SuccessResponseBase
    {

        public GetClassroomResponse()
          : base()
        {
            this.Messages.Add("Lấy dữ liệu thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public GetClassroomResponse(Classroom classroom)
          : this()
        {
            this.Data = new ClassroomResponse(classroom);
        }
    }
}
