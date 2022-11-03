using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Users.Responses
{
    public class GetUserResponse : SuccessResponseBase
    {

        public GetUserResponse()
          : base()
        {
            this.Messages.Add("Lấy dữ liệu thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public GetUserResponse(User user)
          : this()
        {
            this.Data = new UserResponse(user);
        }
    }
}
