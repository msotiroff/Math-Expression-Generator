using MathExpressionGenerator.Common;

namespace MathExpressionGenerator.Models.Expressions.Еquations.Division
{
    public class Division_2v1 : BaseDivision_2v
    {
        public Division_2v1(int a, int b) : base(a, b)
        {
        }

        public override string InstanceRepresentation => $"{a} / {b} = {Constants.EmptyBox}";

        public override string TypeRepresentation => $"a / b = {Constants.EmptyBox}";
    }
}
