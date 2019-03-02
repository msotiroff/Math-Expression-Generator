using MathExpressionGenerator.Common;
using System.Linq;

namespace MathExpressionGenerator.Models.Expressions.Еquations.Addition
{
    public class Addition_3v8 : BaseAdditionEquation
    {
        private readonly int a;
        private readonly int b;
        private readonly int c;
        private readonly int d;

        public Addition_3v8(int a, int b, int c)
        {
            var ordered = new int[] { a, b, c }.OrderByDescending(x => x).ToList();
            this.a = ordered[0];
            this.b = ordered[1];
            this.c = ordered[2];
            this.d = this.a + this.b - this.c;
        }
        
        public override string InstanceRepresentation => $"{a} + {b} = {Constants.EmptyBox} + {d}";

        public override string TypeRepresentation => $"a + b = {Constants.EmptyBox} + d";
    }
}
