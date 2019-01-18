using MathExpressionGenerator.Models.Interfaces;
using System.Collections.Generic;

namespace MathExpressionGenerator.Services.Interfaces
{
    public interface IExpressionContainer
    {
        void Add(IEnumerable<IRepresentable> representables);

        void Clear();

        string GetExpressionsAsString();

        IEnumerable<byte> GetExpressionsAsBytes();
    }
}
