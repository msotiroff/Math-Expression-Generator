using MathExpressionGenerator.Common;
using MathExpressionGenerator.Models.Enums;

namespace MathExpressionGenerator.Models.Expressions.Еquations.Multiplication
{
    public class Multiplication_2v2 : BaseЕquation
    {
        private readonly int a;
        private readonly int b;
        private readonly int result;
        
        public Multiplication_2v2(int a, int b)
        {
            this.a = a;
            this.b = b;

            this.result = this.a * this.b;
        }

        public override ExpressionOperation Operation => ExpressionOperation.Multiplication;

        public override string InstanceRepresentation => $"{Constants.EmptyBox} * {b} = {result}";

        public override string TypeRepresentation => $"{Constants.EmptyBox} * b = c";
    }
}
