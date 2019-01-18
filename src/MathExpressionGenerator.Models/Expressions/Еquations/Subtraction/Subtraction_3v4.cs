namespace MathExpressionGenerator.Models.Expressions.Еquations.Subtraction
{
    using MathExpressionGenerator.Common;
    using MathExpressionGenerator.Models.Enums;
    using System.Collections.Generic;
    using System.Linq;

    public class Subtraction_3v4 : BaseЕquation
    {
        private readonly IList<int> orderdArguments;
        private readonly int a;
        private readonly int b;
        private readonly int c;
        private readonly int result;

        public Subtraction_3v4() : this(0, 0, 0)
        {
        }

        public Subtraction_3v4(int a, int b, int c)
        {
            this.orderdArguments = new List<int> { a, b, c }.OrderBy(x => x).ToList();

            this.b = this.orderdArguments[0];
            this.a = this.orderdArguments[1];
            this.c = this.orderdArguments[2];

            this.result = this.a - this.b + this.c;
        }

        public override ExpressionOperation Operation => ExpressionOperation.Subtraction;

        public override string ObjectRepresentation => $"{a} - {Constants.EmptyBox} + {c} = {result}";

        public override string TypeRepresentation => $"a - {Constants.EmptyBox} + c = d";
    }
}
