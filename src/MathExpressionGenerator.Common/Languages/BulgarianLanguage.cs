namespace MathExpressionGenerator.Common.Languages
{
    public class BulgarianLanguage : ILanguage
    {
        public string ChooseExpressionType => "Изберете вид израз:";

        public string ChooseMinOperand => "Минимален операнд:";

        public string ChooseMaxOperand => "Максимален операнд:";

        public string ExpressionsCount => "Брой изрази:";

        public string Randomize => "Разбъркай";

        public string Clear => "Изчисти";

        public string Add => "Добави";

        public string SaveAs => "Запази като:";

        public string Save => "Запази";

        public string SaveTo => "Запази в:";

        public string OpenFileWhenReady => "Отвори след изпълнение";

        public string ExpressionsFileName => "Уравнения";

        public string InvalidNumberFormatErrorMsg => "\"{0}\" не е валидно число.";

        public string InvalidNumberMinValueErrorMsg => "\"{0}\" е по - малко от минимално допустимото: \"{1}\"";

        public string InvalidNumberMaxValueErrorMsg => "\"{0}\" е по - голямо от максимално допустимото: \"{1}\"";

        public string InvalidDifferenceMinMaxValue => "Максималното число трябва да бъде равно или по - голямо от минималното число!";
        
        public string Language => "Език:";

        public string WindowTitle => "Генератор на уравнения";

        public string Addition => "Събиране";

        public string Subtraction => "Изваждане";

        public string Miltiplication => "Умножение";

        public string Division => "Деление";

        public string Powering => "Степенуване";

        public string SquareRooting => "Коренуване";

        public string DivisionWarningMessage
            => "Внимание: Минималната и максималната стойност на операндите може да вариара, " +
            "ако генерирате уравнения с деление без остатък.";

        public string MaxCountOfExpressionsExceeded
            => $"Максималния брой изрази на всяко генериране е {Constants.ExpressionsCountMaxValue}.";

        public override string ToString() => "Български";
    }
}
