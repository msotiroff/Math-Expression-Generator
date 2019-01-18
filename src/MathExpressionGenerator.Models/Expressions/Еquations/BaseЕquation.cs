using MathExpressionGenerator.Models.Enums;

namespace MathExpressionGenerator.Models.Expressions.Еquations
{
    public abstract class BaseЕquation : BaseMathExpression
    {
        public override ExpressionType Type => ExpressionType.Еquation;
    }
}
