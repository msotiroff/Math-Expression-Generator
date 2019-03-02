using MathExpressionGenerator.Common;

namespace MathExpressionGenerator.Models.Expressions.Еquations.Addition
{
    public class Addition_3v4 : BaseAdditionEquation
    {
        private readonly int a;
        private readonly int b;
        private readonly int c;
        private readonly int d;
        
        public Addition_3v4(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;

            this.d = this.a + this.b + this.c;
        }
        
        public override string InstanceRepresentation => $"{a} + {b} + {Constants.VariableSymbol} = {d}";

        public override string TypeRepresentation => $"a + b + {Constants.VariableSymbol} = d";
    }
}
