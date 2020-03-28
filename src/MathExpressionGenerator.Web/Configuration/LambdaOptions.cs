using DotNetExtensions.Common;
using System;

namespace MathExpressionGenerator.Web.Configuration
{
    public class LambdaOptions
    {
        private string applicationBasePath;

        public string ApplicationBasePath 
        {
            get
            {
                var pathFromEnvironment = Environment.GetEnvironmentVariable("PROXY_URL");

                return pathFromEnvironment.IsNullOrWhiteSpace()
                    ? this.applicationBasePath
                    : pathFromEnvironment;
            }
            set
            {
                this.applicationBasePath = value;
            }
        }

        public string FaviconPath { get; set; }

        public string BackgroundImagePath { get; set; }

        public string DownloadArrowImagePath { get; set; }
    }
}
