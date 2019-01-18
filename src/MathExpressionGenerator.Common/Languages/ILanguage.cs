namespace MathExpressionGenerator.Common.Languages
{
    public interface ILanguage
    {
        string ChooseExpressionType { get; }
        string ChooseMinOperand { get; }
        string ChooseMaxOperand { get; }
        string ExpressionsCount { get; }
        string Randomize { get; }
        string Clear { get; }
        string Add { get; }
        string SaveAs { get; }
        string Save { get; }
        string SaveTo { get; }
        string OpenFileWhenReady { get; }
        string ExpressionsFileName { get; }
        string InvalidNumberFormatErrorMsg { get; }
        string InvalidNumberMinValueErrorMsg { get; }
        string InvalidNumberMaxValueErrorMsg { get; }
        string InvalidDifferenceMinMaxValue { get; }
        string Language { get; }
        string WindowTitle { get; }
        string Addition { get; }
        string Subtraction { get; }
        string Miltiplication { get; }
        string Division { get; }
        string Powering { get; }
        string SquareRooting { get; }
        string DivisionWarningMessage { get; }
        string MaxCountOfExpressionsExceeded { get; }
    }
}
