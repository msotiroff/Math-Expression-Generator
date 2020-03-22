namespace MathExpressionGenerator.Services.Interfaces
{
    using Models.Interfaces;
    using System;
    using System.Collections.Generic;

    public interface IMathExpressionService
    {
        IEnumerable<IRepresentable> GenerateMathExpressions(
            Type expressionType, 
            int minValue, 
            int maxValue, 
            int count = int.MaxValue, 
            bool random = false,
            string variableSymbol = null);
    }
}
