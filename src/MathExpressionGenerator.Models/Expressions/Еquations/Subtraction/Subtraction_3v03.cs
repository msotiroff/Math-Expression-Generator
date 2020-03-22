namespace MathExpressionGenerator.Models.Expressions.Еquations.Subtraction
{
    using MathExpressionGenerator.Common;
    using System.Collections.Generic;
    using System.Linq;

    public class Subtraction_3v03 : BaseSubtractionEquation
    {
        private readonly IList<int> orderdArguments;
        private readonly int a;
        private readonly int b;
        private readonly int c;
        private readonly int result;
        
        public Subtraction_3v03(int a, int b, int c)
        {
            this.orderdArguments = new List<int> { a, b, c }.OrderBy(x => x).ToList();

            this.b = this.orderdArguments[0];
            this.a = this.orderdArguments[1];
            this.c = this.orderdArguments[2];

            this.result = this.a - this.b + this.c;
        }

        public override string InstanceRepresentation => $"{a} - {b} + {c} = {base.VariableSymbol}";

        public override string TypeRepresentation => $"a - b + c = {base.VariableSymbol}";
    }
}
