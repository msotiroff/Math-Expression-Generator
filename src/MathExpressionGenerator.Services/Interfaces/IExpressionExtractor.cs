using MathExpressionGenerator.Common.ViewModels;
using MathExpressionGenerator.Models.Enums;
using System.Collections.Generic;

namespace MathExpressionGenerator.Services.Interfaces
{
    public interface IExpressionExtractor
    {
        IEnumerable<ExpressionViewModel> Extract(
            IEnumerable<ExpressionOperation> operations);
    }
}
