using LFF.Core.Base;
using LFF.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace LFF.Core.DTOs.Registers.Responses
{
    public class ListRegisterResponse : SuccessResponseBase
    {

        public ListRegisterResponse()
          : base()
        {
            this.Messages.Add("Lấy dữ liệu thành công");
            this.Status = "OK";
            this.StatusCode = HttpStatusCode.Accepted;
        }

        public ListRegisterResponse(IEnumerable<Register> registers)
          : this()
        {
            this.Data = registers.Select(u => new RegisterResponse(u));
        }
    }
}
