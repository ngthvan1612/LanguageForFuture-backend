using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Users.Responses
{
    public class UpdateUserResponse : SuccessResponseBase
    {

        public UpdateUserResponse()
          : base()
        {
            this.Messages.Add("Cập nhật người dùng thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public UpdateUserResponse(User user)
          : this()
        {
            this.Data = new UserResponse(user);
        }
    }
}
