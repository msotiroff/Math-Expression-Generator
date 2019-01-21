namespace MathExpressionGenerator.Common.Languages
{
    public class EnglishLanguage : BaseLanguage
    {
        public override string ChooseExpressionType => "Choose Expression Type:";

        public override string ChooseOperationType => "Choose Operation:";

        public override string ChooseMinOperand => "Choose Min Operand:";

        public override string ChooseMaxOperand => "Choose Max Operand:";

        public override string ExpressionsCount => "Expressions count:";

        public override string Randomize => "Randomize";

        public override string Clear => "Clear";

        public override string Add => "Add";

        public override string SaveAs => "Save as:";

        public override string Save => "Save";

        public override string SaveTo => "Save to:";

        public override string OpenFileWhenReady => "Open file when ready";

        public override string ExpressionsFileName => "Math expressions";

        public override string InvalidNumberFormatErrorMsg => "\"{0}\" is not a valid number!";

        public override string InvalidNumberMinValueErrorMsg => $"Smallest possible operand's value is \"{Constants.OperandMinValue}\"";

        public override string InvalidNumberMaxValueErrorMsg => $"Largest possible operand's value is \"{Constants.OperandMaxValue}\"";

        public override string InvalidDifferenceMinMaxValue => "Min number should be equal or less than Max number!";

        public override string Language => "Language:";

        public override string GeneratorTitle => "Expression generator";

        public override string Addition => "Addition";

        public override string Subtraction => "Subtraction";

        public override string Multiplication => "Miltiplication";

        public override string Division => "Division";

        public override string Powering => "Powering";

        public override string SquareRooting => "Square rooting";

        public override string DivisionWarningMessage 
            => "Warning: The min and max operand may vary, if you generate a division without overage.";

        public override string MaxCountOfExpressionsExceeded 
            => $"Max expressions count per singe generation is {Constants.ExpressionsCountMaxValue}.";
        
        public override string ToString() => "English";
    }
}
