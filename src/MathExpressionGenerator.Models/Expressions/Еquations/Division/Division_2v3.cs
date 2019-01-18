using MathExpressionGenerator.Common;

namespace MathExpressionGenerator.Models.Expressions.Еquations.Division
{
    public class Division_2v3 : BaseDivision_2v
    {
        public Division_2v3(int a, int b) : base(a, b)
        {
        }

        public override string ObjectRepresentation => $"{Constants.EmptyBox} / {b} = {result}";

        public override string TypeRepresentation => $"{Constants.EmptyBox} / b = c";
    }
}
