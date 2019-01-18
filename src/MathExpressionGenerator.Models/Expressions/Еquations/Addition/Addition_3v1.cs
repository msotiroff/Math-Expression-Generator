using MathExpressionGenerator.Common;
using MathExpressionGenerator.Models.Enums;

namespace MathExpressionGenerator.Models.Expressions.Еquations.Addition
{
    public class Addition_3v1 : BaseЕquation
    {
        private readonly int a;
        private readonly int b;
        private readonly int c;
        private readonly int result;

        public Addition_3v1() : this(0, 0, 0)
        {
        }

        public Addition_3v1(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;

            this.result = this.a + this.b + this.c;
        }

        public override ExpressionOperation Operation => ExpressionOperation.Addition;

        public override string ObjectRepresentation => $"{a} + {b} + {c} = {Constants.EmptyBox}";

        public override string TypeRepresentation => $"a + b + c = {Constants.EmptyBox}";
    }
}
