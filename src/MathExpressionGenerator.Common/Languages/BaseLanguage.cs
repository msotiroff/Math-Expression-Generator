using System.Linq;

namespace MathExpressionGenerator.Common.Languages
{
    public abstract class BaseLanguage : ILanguage
    {
        public abstract string ChooseExpressionType { get; }
        public abstract string ChooseVariableSymbol { get; }
        public abstract string ChooseOperationType { get; }
        public abstract string ChooseMinOperand { get; }
        public abstract string ChooseMaxOperand { get; }
        public abstract string ExpressionsCount { get; }
        public abstract string Randomize { get; }
        public abstract string Clear { get; }
        public abstract string Add { get; }
        public abstract string SaveAs { get; }
        public abstract string Save { get; }
        public abstract string SaveTo { get; }
        public abstract string OpenFileWhenReady { get; }
        public abstract string ExpressionsFileName { get; }
        public abstract string InvalidNumberFormatErrorMsg { get; }
        public abstract string InvalidNumberMinValueErrorMsg { get; }
        public abstract string InvalidNumberMaxValueErrorMsg { get; }
        public abstract string InvalidDifferenceMinMaxValue { get; }
        public abstract string Language { get; }
        public abstract string GeneratorTitle { get; }
        public abstract string Addition { get; }
        public abstract string Subtraction { get; }
        public abstract string Multiplication { get; }
        public abstract string Division { get; }
        public abstract string Powering { get; }
        public abstract string SquareRooting { get; }
        public abstract string DivisionWarningMessage { get; }
        public abstract string OperandVaryWarningMessage { get; }
        public abstract string MaxCountOfExpressionsExceeded { get; }

        public string GetPropertyValue(string propertyName)
        {
            var value = typeof(BaseLanguage)
                .GetProperties()
                .FirstOrDefault(pi => pi.Name == propertyName)
                ?.GetValue(this) as string;

            return value;
        }
    }
}
