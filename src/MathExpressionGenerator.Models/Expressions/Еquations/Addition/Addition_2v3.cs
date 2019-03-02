using MathExpressionGenerator.Common;

namespace MathExpressionGenerator.Models.Expressions.Еquations.Addition
{
    public class Addition_2v3 : BaseAdditionEquation
    {
        private readonly int a;
        private readonly int b;
        private readonly int c;
        
        public Addition_2v3(int a, int b)
        {
            this.a = a;
            this.b = b;

            this.c = this.a + this.b;
        }
        
        public override string InstanceRepresentation => $"{a} + {Constants.VariableSymbol} = {this.c}";

        public override string TypeRepresentation => $"a + {Constants.VariableSymbol} = c";
    }
}
