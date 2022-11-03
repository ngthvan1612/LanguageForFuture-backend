using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Lectures.Responses
{
    public class GetLectureResponse : SuccessResponseBase
    {

        public GetLectureResponse()
          : base()
        {
            this.Messages.Add("Lấy dữ liệu thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public GetLectureResponse(Lecture lecture)
          : this()
        {
            this.Data = new LectureResponse(lecture);
        }
    }
}
