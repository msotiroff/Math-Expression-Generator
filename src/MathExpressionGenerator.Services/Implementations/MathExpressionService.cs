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
            bool random = false)
        {
            return random
                ? base.GetRandomizedExpressions(minValue, maxValue, count, expressionType)
                : base.GetSortedExpressions(minValue, maxValue, count, expressionType);
        }
    }
}
