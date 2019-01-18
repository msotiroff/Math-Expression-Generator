namespace MathExpressionGenerator.Models.Interfaces
{
    using MathExpressionGenerator.Models.Enums;

    public interface IMathExpression
    {
        ExpressionType Type { get; }
    }
}
