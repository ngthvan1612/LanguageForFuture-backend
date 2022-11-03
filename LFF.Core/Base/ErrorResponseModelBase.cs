using System.Collections.Generic;

namespace LFF.Core.Base
{
    public class ErrorResponseModelBase
    {
        public int Code { get; set; }

        public List<string> Messages { get; set; } = new List<string>();

        public void addMessage(string message)
        {
            var temp = message.Trim();
            if (!string.IsNullOrEmpty(temp))
            {
                ;
                temp = char.ToUpper(temp[0]) + temp.Substring(1);
                this.Messages.Add(temp);
            };
        }
    }
}
