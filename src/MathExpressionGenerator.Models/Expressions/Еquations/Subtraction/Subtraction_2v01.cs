namespace MathExpressionGenerator.Models.Expressions.Еquations.Subtraction
{
    using MathExpressionGenerator.Common;
    using System;

    public class Subtraction_2v01 : BaseSubtractionEquation
    {
        private readonly int a;
        private readonly int b;
        private readonly int result;
        
        public Subtraction_2v01(int a, int b)
        {
            this.a = Math.Max(a, b);
            this.b = Math.Min(a, b);

            this.result = this.a - this.b;
        }
        
        public override string InstanceRepresentation => $"{a} - {b} = {Constants.VariableSymbol}";

        public override string TypeRepresentation => $"a - b = {Constants.VariableSymbol}";
    }
}
