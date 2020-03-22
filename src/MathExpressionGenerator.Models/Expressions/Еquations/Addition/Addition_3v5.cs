using MathExpressionGenerator.Common;

namespace MathExpressionGenerator.Models.Expressions.Еquations.Addition
{
    public class Addition_3v5 : BaseAdditionEquation
    {
        private readonly int a;
        private readonly int b;
        private readonly int c;
        private readonly int d;

        public Addition_3v5(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = a + b + c;
        }
        
        public override string InstanceRepresentation => $"{base.VariableSymbol} + {b} + {c} = {d}";

        public override string TypeRepresentation => $"{base.VariableSymbol} + b + c = d";
    }
}
