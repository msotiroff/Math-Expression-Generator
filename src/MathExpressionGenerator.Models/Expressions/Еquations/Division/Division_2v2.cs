using MathExpressionGenerator.Common;

namespace MathExpressionGenerator.Models.Expressions.Еquations.Division
{
    public class Division_2v2 : BaseDivision_2v
    {
        public Division_2v2(int a, int b) : base(a, b)
        {
        }

        public override string InstanceRepresentation => $"{a} : {base.VariableSymbol} = {result}";

        public override string TypeRepresentation => $"a : {base.VariableSymbol} = c";
    }
}
