namespace MathExpressionGenerator.Models.Expressions.Еquations.Subtraction
{
    using MathExpressionGenerator.Common;
    using System.Collections.Generic;
    using System.Linq;

    public class Subtraction_3v02 : BaseSubtractionEquation
    {
        private readonly IList<int> orderedArguments;
        private readonly int a;
        private readonly int b;
        private readonly int c;
        private readonly int result;
        
        public Subtraction_3v02(int a, int b, int c)
        {
            this.orderedArguments = new List<int> { a, b, c }.OrderBy(x => x).ToList();

            this.a = this.orderedArguments[2];
            this.b = this.orderedArguments[1];
            this.c = this.orderedArguments[0];

            this.result = this.a + this.b - this.c;
        }
        
        public override string InstanceRepresentation => $"{a} + {Constants.EmptyBox} - {c} = {result}";

        public override string TypeRepresentation => $"a + {Constants.EmptyBox} - c = d";
    }
}
