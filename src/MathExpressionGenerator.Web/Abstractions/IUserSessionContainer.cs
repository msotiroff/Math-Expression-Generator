using MathExpressionGenerator.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MathExpressionGenerator.Web.Abstractions
{
    public interface IUserSessionContainer
    {
        Task AddAsync(HttpContext context, IEnumerable<IRepresentable> representables);

        Task ClearAsync(HttpContext context);

        Task<string> GetExpressionsAsStringAsync(HttpContext context);

        Task<IEnumerable<byte>> GetExpressionsAsBytesAsync(HttpContext context);
    }
}