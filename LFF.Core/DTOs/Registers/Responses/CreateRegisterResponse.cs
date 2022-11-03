using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Registers.Responses
{
    public class CreateRegisterResponse : SuccessResponseBase
    {

        public CreateRegisterResponse()
          : base()
        {
            this.Messages.Add("Tạo đăng ký thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Created;
        }

        public CreateRegisterResponse(Register register)
          : this()
        {
            this.Data = new RegisterResponse(register);
        }
    }
}
