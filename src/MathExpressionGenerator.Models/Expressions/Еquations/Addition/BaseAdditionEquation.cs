using MathExpressionGenerator.Models.Enums;

namespace MathExpressionGenerator.Models.Expressions.Еquations.Addition
{
    public abstract class BaseAdditionEquation : BaseЕquation
    {
        public override ExpressionOperation Operation => ExpressionOperation.Addition;
    }
}
