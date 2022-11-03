using LFF.Core.Base;
using LFF.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace LFF.Core.DTOs.Users.Responses
{
    public class ListUserResponse : SuccessResponseBase
    {

        public ListUserResponse()
          : base()
        {
            this.Messages.Add("Lấy dữ liệu thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public ListUserResponse(IEnumerable<User> users)
          : this()
        {
            this.Data = users.Select(u => new UserResponse(u));
        }
    }
}
