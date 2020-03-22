using MathExpressionGenerator.Common;
using MathExpressionGenerator.Models.Enums;

namespace MathExpressionGenerator.Models.Expressions.Еquations.Multiplication
{
    public class Multiplication_3v3 : BaseЕquation
    {
        private readonly int a;
        private readonly int b;
        private readonly int c;
        private readonly int result;
        
        public Multiplication_3v3(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;

            this.result = this.a * this.b * this.c;
        }

        public override ExpressionOperation Operation => ExpressionOperation.Multiplication;

        public override string InstanceRepresentation => $"{a} * {base.VariableSymbol} * {c} = {result}";

        public override string TypeRepresentation => $"a * {base.VariableSymbol} * c = d";
    }
}
