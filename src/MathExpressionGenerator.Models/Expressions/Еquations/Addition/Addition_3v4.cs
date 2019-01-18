using MathExpressionGenerator.Common;
using MathExpressionGenerator.Models.Enums;

namespace MathExpressionGenerator.Models.Expressions.Еquations.Addition
{
    public class Addition_3v4 : BaseЕquation
    {
        private readonly int a;
        private readonly int b;
        private readonly int c;
        private readonly int result;

        public Addition_3v4() : this(0, 0, 0)
        {
        }

        public Addition_3v4(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;

            this.result = this.a + this.b + this.c;
        }

        public override ExpressionOperation Operation => ExpressionOperation.Addition;

        public override string ObjectRepresentation => $"{a} + {b} + {Constants.EmptyBox} = {result}";

        public override string TypeRepresentation => $"a + b + {Constants.EmptyBox} = d";
    }
}
