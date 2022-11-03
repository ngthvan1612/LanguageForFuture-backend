using System;

namespace LFF.Core.Base
{
    public class BaseDomainException : Exception
    {
        public ErrorResponseModelBase Error { get; set; } = new ErrorResponseModelBase();

        public static BaseDomainException NotFound(params string[] messages)
        {
            var response = new BaseDomainException();
            response.Error.Code = 404;
            foreach (var message in messages)
            {
                response.Error.addMessage(message);
            }
            return response;
        }

        public static BaseDomainException BadRequest(params string[] messages)
        {
            var response = new BaseDomainException();
            response.Error.Code = 400;
            foreach (var message in messages)
            {
                response.Error.addMessage(message);
            }
            return response;
        }
    }
}
