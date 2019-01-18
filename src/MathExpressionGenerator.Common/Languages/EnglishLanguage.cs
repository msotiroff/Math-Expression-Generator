namespace MathExpressionGenerator.Common.Languages
{
    public class EnglishLanguage : ILanguage
    {
        public string ChooseExpressionType => "Choose Expression Type:";

        public string ChooseMinOperand => "Choose Min Operand:";

        public string ChooseMaxOperand => "Choose Max Operand:";

        public string ExpressionsCount => "Expressions count:";

        public string Randomize => "Randomize";

        public string Clear => "Clear";

        public string Add => "Add";

        public string SaveAs => "Save as:";

        public string Save => "Save";

        public string SaveTo => "Save to:";

        public string OpenFileWhenReady => "Open file when ready";

        public string ExpressionsFileName => "Math expressions";

        public string InvalidNumberFormatErrorMsg => "\"{0}\" is not a valid number!";

        public string InvalidNumberMinValueErrorMsg => "\"{0}\" is less than the minimum possible value: \"{1}\"";

        public string InvalidNumberMaxValueErrorMsg => "\"{0}\" is more than the maximum possible value: \"{1}\"";

        public string InvalidDifferenceMinMaxValue => "Min number should be equal or less than Max number!";
        
        public string Language => "Language:";

        public string WindowTitle => "Expression generator";

        public string Addition => "Addition";

        public string Subtraction => "Subtraction";

        public string Miltiplication => "Miltiplication";

        public string Division => "Division";

        public string Powering => "Powering";

        public string SquareRooting => "Square rooting";

        public string DivisionWarningMessage 
            => "Warning: The min and max operand may vary, if you generate a division without overage.";

        public string MaxCountOfExpressionsExceeded 
            => $"Max expressions count per singe generation is {Constants.ExpressionsCountMaxValue}.";

        public override string ToString() => "English";
    }
}
