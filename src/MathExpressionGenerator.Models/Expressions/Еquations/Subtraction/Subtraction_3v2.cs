namespace MathExpressionGenerator.Models.Expressions.Еquations.Subtraction
{
    using MathExpressionGenerator.Common;
    using MathExpressionGenerator.Models.Enums;
    using System.Collections.Generic;
    using System.Linq;

    public class Subtraction_3v2 : BaseЕquation
    {
        private readonly IList<int> orderedArguments;
        private readonly int a;
        private readonly int b;
        private readonly int c;
        private readonly int result;

        public Subtraction_3v2() : this(0, 0, 0)
        {
        }

        public Subtraction_3v2(int a, int b, int c)
        {
            this.orderedArguments = new List<int> { a, b, c }.OrderBy(x => x).ToList();

            this.a = this.orderedArguments[2];
            this.b = this.orderedArguments[1];
            this.c = this.orderedArguments[0];

            this.result = this.a + this.b - this.c;
        }

        public override ExpressionOperation Operation => ExpressionOperation.Subtraction;

        public override string ObjectRepresentation => $"{a} + {Constants.EmptyBox} - {c} = {result}";

        public override string TypeRepresentation => $"a + {Constants.EmptyBox} - c = d";
    }
}
