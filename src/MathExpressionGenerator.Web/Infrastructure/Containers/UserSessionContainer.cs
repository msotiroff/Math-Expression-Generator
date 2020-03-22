using DotNetExtensions.AspNetCore.Common;
using DotNetExtensions.Common;
using DotNetExtensions.Compression;
using DotNetExtensions.Json;
using MathExpressionGenerator.Models.Expressions;
using MathExpressionGenerator.Models.Interfaces;
using MathExpressionGenerator.Services.Implementations;
using MathExpressionGenerator.Services.Interfaces;
using MathExpressionGenerator.Web.Abstractions;
using MathExpressionGenerator.Web.Data.Abstractions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MathExpressionGenerator.Web.Infrastructure.Containers
{
    public class UserSessionContainer : IUserSessionContainer
    {
        private readonly IBrowserRepository browserRepository;

        public UserSessionContainer(IBrowserRepository browserRepository)
        {
            this.browserRepository = browserRepository;
        }

        public async Task AddAsync(HttpContext context, IEnumerable<IRepresentable> representables)
        {
            if (context.IsNull())
            {
                return;
            }

            if (representables.IsNullOrEmpty())
            {
                return;
            }

            var browserId = context.GetBrowserId();
            var browser = await this.browserRepository.GetAsync(browserId);
            var decompressed = browser?.CompressedExpressions?.TryDecompress();
            var userExpressions = decompressed
                ?.TryDeserializeFromJson<IEnumerable<BaseMathExpression>>()
                ?.ToList()
                ?? new List<BaseMathExpression>();

            userExpressions.AddRange(representables.Cast<BaseMathExpression>());

            var serializedExpressions = userExpressions.ToJson(Formatting.None);
            var compressedExpressions = serializedExpressions.Compress();

            browser.CompressedExpressions = compressedExpressions;

            await this.browserRepository.SaveAsync(browser);
        }

        public async Task ClearAsync(HttpContext context)
        {
            var browserId = context.GetBrowserId();

            await this.browserRepository.DeleteAsync(browserId);
        }

        public async Task<string> GetExpressionsAsStringAsync(HttpContext context)
        {
            if (context.IsNull())
            {
                return default;
            }

            var container = await this.GetExpressionContainerAsync(context);

            return container.GetExpressionsAsString();
        }

        public async Task<IEnumerable<byte>> GetExpressionsAsBytesAsync(HttpContext context)
        {
            if (context.IsNull())
            {
                return default;
            }

            var container = await this.GetExpressionContainerAsync(context);

            return container.GetExpressionsAsBytes();
        }

        private async Task<IExpressionContainer> GetExpressionContainerAsync(HttpContext context)
        {
            var expressions = await this.GetExpressionsAsync(context);
            var container = new ExpressionContainer();

            container.Add(expressions.Cast<IRepresentable>());

            return container;
        }

        private async Task<IEnumerable<BaseMathExpression>> GetExpressionsAsync(HttpContext context)
        {
            var browserId = context.GetBrowserId();
            var browser = await this.browserRepository.GetAsync(browserId);
            var decompressed = browser?.CompressedExpressions?.TryDecompress();
            var deserialized = decompressed
                .TryDeserializeFromJson<IEnumerable<BaseMathExpression>>();

            return deserialized ?? Enumerable.Empty<BaseMathExpression>();
        }
    }
}
