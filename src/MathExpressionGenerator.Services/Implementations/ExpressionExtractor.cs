using MathExpressionGenerator.Common.ViewModels;
using MathExpressionGenerator.Models.Enums;
using MathExpressionGenerator.Models.Expressions;
using MathExpressionGenerator.Models.Interfaces;
using MathExpressionGenerator.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace MathExpressionGenerator.Services.Implementations
{
    public class ExpressionExtractor : IExpressionExtractor
    {
        public IEnumerable<ExpressionViewModel> Extract(
            IEnumerable<ExpressionOperation> operations)
        {
            var expressions = Assembly
                .GetAssembly(typeof(BaseMathExpression))
                .GetTypes()
                .Where(t => t.IsClass
                    && !t.IsGenericType
                    && !t.IsAbstract
                    && typeof(BaseMathExpression) != t
                    && typeof(BaseMathExpression).IsAssignableFrom(t))
                .Select(t => FormatterServices.GetUninitializedObject(t))
                .Cast<BaseMathExpression>()
                .Where(expr => operations.Any(op => (int)op == (int)expr.Operation))
                .Cast<IRepresentable>()
                .Select(t => new ExpressionViewModel
                {
                    Type = t.GetType(),
                    Representation = t.TypeRepresentation
                })
                .OrderBy(a => a.Representation.Length)
                .ThenBy(a => a.Type.Name)
                .ToList();

            return expressions;
        }
    }
}
