using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Registers.Responses
{
    public class UpdateRegisterResponse : SuccessResponseBase
    {

        public UpdateRegisterResponse()
          : base()
        {
            this.Messages.Add("Cập nhật đăng ký thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public UpdateRegisterResponse(Register register)
          : this()
        {
            this.Data = new RegisterResponse(register);
        }
    }
}
