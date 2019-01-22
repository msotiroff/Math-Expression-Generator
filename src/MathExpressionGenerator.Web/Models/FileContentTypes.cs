using System.Collections.Generic;

namespace MathExpressionGenerator.Web.Models
{
    public class FileContentTypes
    {
        public Dictionary<string, string> ContentTypes { get; set; }

        public string this[string key] => this.ContentTypes.GetValueOrDefault(key);
    }
}
