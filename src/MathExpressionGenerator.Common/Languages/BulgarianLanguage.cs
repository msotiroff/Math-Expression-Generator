namespace MathExpressionGenerator.Common.Languages
{
    public class BulgarianLanguage : BaseLanguage
    {
        public override string ChooseExpressionType => "Изберете вид израз:";
               
        public override string ChooseOperationType => "Изберете операция:";
               
        public override string ChooseMinOperand => "Минимален операнд:";
               
        public override string ChooseMaxOperand => "Максимален операнд:";
               
        public override string ExpressionsCount => "Брой изрази:";
               
        public override string Randomize => "Разбъркай";
               
        public override string Clear => "Изчисти";
               
        public override string Add => "Добави";
               
        public override string SaveAs => "Запази като:";
               
        public override string Save => "Запази";
               
        public override string SaveTo => "Запази в:";
               
        public override string OpenFileWhenReady => "Отвори след изпълнение";
               
        public override string ExpressionsFileName => "Уравнения";
               
        public override string InvalidNumberFormatErrorMsg => "\"{0}\" не е валидно число.";
               
        public override string InvalidNumberMinValueErrorMsg => $"Минимално допустимата стойност на операнд е \"{Constants.OperandMinValue}\"";
               
        public override string InvalidNumberMaxValueErrorMsg => $"Максимално допустимата стойност на операнд е \"{Constants.OperandMaxValue}\"";
               
        public override string InvalidDifferenceMinMaxValue => "Максималното число трябва да бъде равно или по - голямо от минималното число!";
               
        public override string Language => "Език:";
               
        public override string GeneratorTitle => "Генератор на уравнения";
               
        public override string Addition => "Събиране";
               
        public override string Subtraction => "Изваждане";
               
        public override string Multiplication => "Умножение";
               
        public override string Division => "Деление";
               
        public override string Powering => "Степенуване";
               
        public override string SquareRooting => "Коренуване";
               
        public override string DivisionWarningMessage
            => "Внимание: Минималната и максималната стойност на операндите може да вариара, " +
            "ако генерирате уравнения с деление без остатък.";

        public override string MaxCountOfExpressionsExceeded
            => $"Максималния брой изрази на всяко генериране е {Constants.ExpressionsCountMaxValue}.";

        public override string ToString() => "Български";
    }
}
