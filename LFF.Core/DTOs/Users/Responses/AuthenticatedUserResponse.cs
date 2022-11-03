using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Users.Responses
{
    public class AuthenticatedUserResponse : SuccessResponseBase
    {
        public string AccessToken { get; set; } = "";
        private readonly User _storedUser;

        public AuthenticatedUserResponse(User user)
        {
            this.Messages.Add("Đăng nhập thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
            this.Data = new UserResponse(user);
            this._storedUser = user;
        }

        public User GetStoredUser() => this._storedUser;
    }
}
