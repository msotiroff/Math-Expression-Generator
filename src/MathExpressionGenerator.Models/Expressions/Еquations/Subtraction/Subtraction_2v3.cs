namespace MathExpressionGenerator.Models.Expressions.Еquations.Subtraction
{
    using MathExpressionGenerator.Common;
    using MathExpressionGenerator.Models.Enums;
    using System;

    public class Subtraction_2v3 : BaseЕquation
    {
        private readonly int a;
        private readonly int b;
        private readonly int result;

        public Subtraction_2v3() : this(0, 0)
        {
        }

        public Subtraction_2v3(int a, int b)
        {
            this.a = Math.Max(a, b);
            this.b = Math.Min(a, b);

            this.result = this.a - this.b;
        }

        public override ExpressionOperation Operation => ExpressionOperation.Subtraction;

        public override string ObjectRepresentation => $"{Constants.EmptyBox} - {b} = {result}";

        public override string TypeRepresentation => $"{Constants.EmptyBox} - b = c";
    }
}
