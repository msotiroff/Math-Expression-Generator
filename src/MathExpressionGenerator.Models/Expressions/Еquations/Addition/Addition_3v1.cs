using MathExpressionGenerator.Common;

namespace MathExpressionGenerator.Models.Expressions.Еquations.Addition
{
    public class Addition_3v1 : BaseAdditionEquation
    {
        private readonly int a;
        private readonly int b;
        private readonly int c;
        private readonly int d;
        
        public Addition_3v1(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;

            this.d = this.a + this.b + this.c;
        }
        
        public override string InstanceRepresentation => $"{a} + {b} + {c} = {base.VariableSymbol}";

        public override string TypeRepresentation => $"a + b + c = {base.VariableSymbol}";
    }
}
