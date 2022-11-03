using LFF.Core.Base;
using LFF.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace LFF.Core.DTOs.Lectures.Responses
{
    public class ListLectureResponse : SuccessResponseBase
    {

        public ListLectureResponse()
          : base()
        {
            this.Messages.Add("Lấy dữ liệu thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public ListLectureResponse(IEnumerable<Lecture> lectures)
          : this()
        {
            this.Data = lectures.Select(u => new LectureResponse(u));
        }
    }
}
