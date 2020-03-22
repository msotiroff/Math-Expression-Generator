using Amazon.Lambda.Core;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MathExpressionGenerator.Web.LambdaFunctions
{
    public class WarmerEntryPoint
    {
        private static HttpClient httpClient;

        public WarmerEntryPoint()
        {
            this.InstantiateHttpClient();
        }

        public async Task WarmAsync(ILambdaContext lambdaContext)
        {
            lambdaContext.Logger.LogLine("Warming the proxy function...");

            var tasks = new Task[]
            {
                Task.Run(async () => await httpClient.GetAsync(
                    Environment.GetEnvironmentVariable("PROXY_URL") + "home/index"))
            };

            await Task.WhenAll(tasks);

            lambdaContext.Logger.LogLine("Proxy function warmed.");
        }
        private void InstantiateHttpClient()
        {
            if (httpClient != null)
            {
                return;
            }

            Console.WriteLine("Instantiating a new http client...");

            httpClient = new HttpClient();
        }
    }
}
