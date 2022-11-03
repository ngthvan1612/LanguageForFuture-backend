using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Lectures.Responses
{
    public class CreateLectureResponse : SuccessResponseBase
    {

        public CreateLectureResponse()
          : base()
        {
            this.Messages.Add("Tạo bài giảng thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Created;
        }

        public CreateLectureResponse(Lecture lecture)
          : this()
        {
            this.Data = new LectureResponse(lecture);
        }
    }
}
