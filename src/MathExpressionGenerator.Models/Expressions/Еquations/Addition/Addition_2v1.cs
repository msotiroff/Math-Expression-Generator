using MathExpressionGenerator.Common;

namespace MathExpressionGenerator.Models.Expressions.Еquations.Addition
{
    public class Addition_2v1 : BaseAdditionEquation
    {
        private readonly int a;
        private readonly int b;
        private readonly int c;
        
        public Addition_2v1(int a, int b)
        {
            this.a = a;
            this.b = b;

            this.c = this.a + this.b;
        }
        
        public override string InstanceRepresentation => $"{a} + {b} = {Constants.VariableSymbol}";

        public override string TypeRepresentation => $"a + b = {Constants.VariableSymbol}";
    }
}
