using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Users.Responses
{
    public class CreateUserResponse : SuccessResponseBase
    {

        public CreateUserResponse()
          : base()
        {
            this.Messages.Add("Tạo người dùng thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Created;
        }

        public CreateUserResponse(User user)
          : this()
        {
            this.Data = new UserResponse(user);
        }
    }
}
