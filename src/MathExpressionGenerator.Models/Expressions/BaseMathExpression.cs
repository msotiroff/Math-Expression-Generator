namespace MathExpressionGenerator.Models.Expressions
{
    using Interfaces;
    using MathExpressionGenerator.Models.Enums;

    public abstract class BaseMathExpression : IMathExpression, IRepresentable
    {
        public abstract ExpressionType Type { get; }

        public abstract ExpressionOperation Operation { get; }

        public abstract string ObjectRepresentation { get; }

        public abstract string TypeRepresentation { get; }

        public override string ToString() => this.TypeRepresentation;
    }
}
