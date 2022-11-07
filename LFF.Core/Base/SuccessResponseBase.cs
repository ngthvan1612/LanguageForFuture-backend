using System.Collections.Generic;

namespace LFF.Core.Base
{
    public class SuccessResponseBase : ResponseBase
    {
        public List<string> Messages { get; set; } = new List<string>();

        public object? Data { get; set; }

        public SuccessResponseBase()
        {
            this.StatusCode = System.Net.HttpStatusCode.OK;
        }

        public static SuccessResponseBase Send(params string[] messages)
        {
            var response = new SuccessResponseBase();
            foreach (var message in messages)
            {
                response.Messages.Add(message);
            }
            return response;
        }
    }
}
