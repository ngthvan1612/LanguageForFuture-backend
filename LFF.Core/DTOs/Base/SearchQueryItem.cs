using System.Collections.Generic;

namespace LFF.Core.DTOs.Base
{
    public class SearchQueryItem
    {
        public string Name { get; set; }

        public List<string> Values { get; set; }

        public SearchQueryItem(KeyValuePair<string, IList<string>> source)
        {
            this.Name = source.Key;
            this.Values = new List<string>();
            this.Values.AddRange(source.Value);
        }
    }
}
