using LFF.Core.Base;
using LFF.Core.Entities;
using System.Net;

namespace LFF.Core.DTOs.Registers.Responses
{
    public class GetRegisterResponse : SuccessResponseBase
    {

        public GetRegisterResponse()
          : base()
        {
            this.Messages.Add("Lấy dữ liệu thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public GetRegisterResponse(Register register)
          : this()
        {
            this.Data = new RegisterResponse(register);
        }
    }
}
