using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using DotNetExtensions.Common;
using MathExpressionGenerator.Web.Data.Abstractions;
using MathExpressionGenerator.Web.Data.Models;
using System;
using System.Threading.Tasks;

namespace MathExpressionGenerator.Web.Data.DAL
{
    public class BrowserRepository : IBrowserRepository
    {
        private readonly IDynamoDBContext context;
        private readonly DynamoDBOperationConfig config;

        public BrowserRepository(IAmazonDynamoDB client, string tableName)
        {
            this.config = new DynamoDBOperationConfig
            {
                OverrideTableName = tableName
            };
            this.context = new DynamoDBContext(client, this.config);
        }

        public async Task DeleteAsync(string id)
        {
            if (id.IsNullOrWhiteSpace())
            {
                return;
            }

            Console.WriteLine($"Deleting a Browser it id: {id}...");

            await this.context.DeleteAsync<Browser>(id, this.config);
        }

        public async Task<Browser> GetAsync(string id)
        {
                if (id.IsNullOrWhiteSpace())
                {
                    return default;
                }

                var browser = await this.context.LoadAsync<Browser>(id, this.config);

                if (browser.IsNull())
                {
                    browser = new Browser
                    {
                        Id = id
                    };
                }

                return browser;
        }

        public async Task SaveAsync(Browser browser)
        {
            if (browser.IsNull())
            {
                return;
            }

            browser.LastModified = DateTime.UtcNow;
            browser.ExpirationTime = browser.LastModified.AddMonths(1).ToUnixTime() / 1000;

            await this.context.SaveAsync(browser, this.config);
        }
    }
}
