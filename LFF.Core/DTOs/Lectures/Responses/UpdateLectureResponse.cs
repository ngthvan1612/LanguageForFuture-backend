using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Lectures.Responses
{
    public class UpdateLectureResponse : SuccessResponseBase
    {

        public UpdateLectureResponse()
          : base()
        {
            this.Messages.Add("Cập nhật bài giảng thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public UpdateLectureResponse(Lecture lecture)
          : this()
        {
            this.Data = new LectureResponse(lecture);
        }
    }
}
