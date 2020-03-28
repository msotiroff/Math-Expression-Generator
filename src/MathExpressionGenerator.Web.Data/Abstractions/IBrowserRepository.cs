using System.Threading.Tasks;
using MathExpressionGenerator.Web.Data.Models;

namespace MathExpressionGenerator.Web.Data.Abstractions
{
    public interface IBrowserRepository
    {
        Task<Browser> GetAsync(string id);

        Task SaveAsync(Browser browser);

        Task ClearAsync(string id);
    }
}