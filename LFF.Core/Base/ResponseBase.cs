using System.Net;

namespace LFF.Core.Base
{
    public abstract class ResponseBase
    {
        public string? Status { get; set; }

        protected HttpStatusCode StatusCode { get; set; } = HttpStatusCode.BadRequest;

        public HttpStatusCode GetStatusCode()
        {
            return this.StatusCode;
        }
    }
}
