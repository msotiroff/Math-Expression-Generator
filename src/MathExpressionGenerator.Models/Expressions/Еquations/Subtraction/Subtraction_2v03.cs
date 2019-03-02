namespace MathExpressionGenerator.Models.Expressions.Еquations.Subtraction
{
    using MathExpressionGenerator.Common;
    using System;

    public class Subtraction_2v03 : BaseSubtractionEquation
    {
        private readonly int a;
        private readonly int b;
        private readonly int result;
        
        public Subtraction_2v03(int a, int b)
        {
            this.a = Math.Max(a, b);
            this.b = Math.Min(a, b);

            this.result = this.a - this.b;
        }
        
        public override string InstanceRepresentation => $"{Constants.VariableSymbol} - {b} = {result}";

        public override string TypeRepresentation => $"{Constants.VariableSymbol} - b = c";
    }
}
