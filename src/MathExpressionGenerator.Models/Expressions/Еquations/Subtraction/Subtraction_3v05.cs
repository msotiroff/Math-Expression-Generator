using MathExpressionGenerator.Common;
using System.Linq;

namespace MathExpressionGenerator.Models.Expressions.Еquations.Subtraction
{
    public class Subtraction_3v05 : BaseSubtractionEquation
    {
        private readonly int a;
        private readonly int b;
        private readonly int c;
        private readonly int d;

        public Subtraction_3v05(int a, int b, int c)
        {
            var ordered = new int[] { a, b, c }.OrderByDescending(x => x).ToList();
            this.a = ordered[0];
            this.b = ordered[1];
            this.c = ordered[2];
            this.d = this.a + this.b - this.c;
        }

        public override string InstanceRepresentation => $"{Constants.EmptyBox} + {b} - {c} = {d}";

        public override string TypeRepresentation => $"{Constants.EmptyBox} + b - c = d";
    }
}
