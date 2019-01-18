namespace MathExpressionGenerator.Common.ViewModels
{
    using System;

    public class ExpressionViewModel
    {
        public Type Type { get; set; }

        public string Representation { get; set; }

        public override string ToString() => this.Representation;
    }
}
