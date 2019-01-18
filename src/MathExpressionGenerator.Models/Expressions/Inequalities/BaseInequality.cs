namespace MathExpressionGenerator.Models.Expressions.Inequalities
{
    using Enums;

    public abstract class BaseInequality : BaseMathExpression
    {
        public override ExpressionType Type => ExpressionType.Inequality;
    }
}
