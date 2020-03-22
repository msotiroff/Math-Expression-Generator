namespace MathExpressionGenerator.Services.Implementations
{
    using Interfaces;
    using Models.Factories.Interfaces;
    using Models.Interfaces;
    using System;
    using System.Collections.Generic;

    public class MathExpressionService : BaseMathExpressionService, IMathExpressionService
    {
        public MathExpressionService(IMathExpressionFactory factory, Random random)
            : base(factory, random)
        {
        }
        
        public IEnumerable<IRepresentable> GenerateMathExpressions(
            Type expressionType, 
            int minValue, 
            int maxValue, 
            int count = int.MaxValue, 
            bool random = false,
            string variableSymbol = null)
        {
            var expressions = random
                ? base.GetRandomizedExpressions(
                    minValue, maxValue, count, expressionType)
                : base.GetSortedExpressions(
                    minValue, maxValue, count, expressionType);

            foreach (var expression in expressions)
            {
                var castedExpr = expression as IMathExpression;

                if (castedExpr == null)
                {
                    continue;
                }

                castedExpr.VariableSymbol = variableSymbol;
            }

            return expressions;
        }
    }
}
