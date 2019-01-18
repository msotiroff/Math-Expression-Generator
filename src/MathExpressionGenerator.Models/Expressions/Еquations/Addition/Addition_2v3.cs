using MathExpressionGenerator.Common;
using MathExpressionGenerator.Models.Enums;

namespace MathExpressionGenerator.Models.Expressions.Еquations.Addition
{
    public class Addition_2v3 : BaseЕquation
    {
        private readonly int a;
        private readonly int b;
        private readonly int result;

        public Addition_2v3() : this(0, 0)
        {
        }

        public Addition_2v3(int a, int b)
        {
            this.a = a;
            this.b = b;

            this.result = this.a + this.b;
        }

        public override ExpressionOperation Operation => ExpressionOperation.Addition;

        public override string ObjectRepresentation => $"{a} + {Constants.EmptyBox} = {this.result}";

        public override string TypeRepresentation => $"a + {Constants.EmptyBox} = c";
    }
}
