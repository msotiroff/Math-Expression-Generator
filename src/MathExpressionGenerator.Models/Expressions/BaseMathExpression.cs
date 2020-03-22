namespace MathExpressionGenerator.Models.Expressions
{
    using Interfaces;
    using MathExpressionGenerator.Common;
    using MathExpressionGenerator.Models.Enums;

    public class BaseMathExpression : IMathExpression, IRepresentable
    {
        private string variableSymbol;

        public virtual ExpressionType Type { get; set; }

        public virtual ExpressionOperation Operation { get; set; }

        public virtual string InstanceRepresentation { get; set; }

        public virtual string TypeRepresentation { get; set; }

        public string VariableSymbol 
        { 
            get
            {
                return string.IsNullOrWhiteSpace(this.variableSymbol)
                    ? Constants.VariableSymbol
                    : this.variableSymbol;
            }
            set
            {
                this.variableSymbol = value;
            } 
        }

        public override string ToString() => this.TypeRepresentation;
    }
}
