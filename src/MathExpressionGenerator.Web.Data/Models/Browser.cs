using Amazon.DynamoDBv2.DataModel;
using System;

namespace MathExpressionGenerator.Web.Data.Models
{
    public class Browser
    {
        public Browser()
        {
            this.Created = DateTime.UtcNow;
        }

        [DynamoDBHashKey]
        public string Id { get; set; }

        public string CompressedExpressions { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastModified { get; set; }

        public long ExpirationTime { get; set; }
    }
}
