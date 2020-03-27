using System.Collections.Generic;
using System.Linq;

namespace MathExpressionGenerator.Common
{
    public class Constants
    {
        public const int OperandMinValue = int.MinValue;

        public const int OperandMaxValue = int.MaxValue;

        public const int ExpressionsCountMaxValue = 10_000;

        public static string VariableSymbol { get; set; } = "___";

        public static IEnumerable<string> AllPossibleVarialbeSymbols =
            new List<string>
            {
                "___",
                "[  ]",
                //"\u0020\u20E3\u0020",
                "X",
                "Y",
                "Z"
            };
    }
}
