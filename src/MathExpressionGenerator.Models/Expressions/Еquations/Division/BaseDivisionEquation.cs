using MathExpressionGenerator.Models.Enums;

namespace MathExpressionGenerator.Models.Expressions.Еquations.Division
{
    public abstract class BaseDivisionEquation : BaseЕquation
    {
        public override ExpressionOperation Operation => ExpressionOperation.Division;
    }
}
