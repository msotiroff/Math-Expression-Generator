using MathExpressionGenerator.Models.Enums;

namespace MathExpressionGenerator.Models.Expressions.Еquations.Subtraction
{
    public abstract class BaseSubtractionEquation : BaseЕquation
    {
        public override ExpressionOperation Operation => ExpressionOperation.Subtraction;
    }
}
