namespace MathExpressionGenerator.Services.Implementations
{
    using Extensions;
    using Models.Factories.Interfaces;
    using Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class BaseMathExpressionService
    {
        private static int[] elements;
        private static int elementsPerRow;
        private static object[] vector;
        private static int staticExprCount;
        private static Type expressionType;
        private static List<IRepresentable> allExpressions;

        private readonly IMathExpressionFactory factory;
        private readonly Random random;

        protected BaseMathExpressionService(IMathExpressionFactory factory, Random random)
        {
            this.factory = factory;
            this.random = random;
        }

        protected IEnumerable<IRepresentable> GetRandomizedExpressions(
            int minValue, int maxValue, int expressionsCount, Type type)
        {
            var constructorParametersCount = this.GetConstructorParametersCount(type);

            var allCombinations = new List<IRepresentable>();
            var rest = expressionsCount;

            while (rest > 0)
            {
                // Generate needed count of numbers
                var parameters = new List<object>();
                for (int i = 0; i < constructorParametersCount; i++)
                {
                    parameters.Add(random.Next(minValue, maxValue + 1));
                }

                var instance = this.factory.GetInstance(type, parameters.ToArray());
                allCombinations.Add(instance);

                rest--;
            }

            return allCombinations;
        }

        protected IEnumerable<IRepresentable> GetSortedExpressions(
            int minValue, int maxValue, int expressionsCount, Type type)
        {
            var constructorParametersCount = this.GetConstructorParametersCount(type);

            allExpressions = new List<IRepresentable>();
            elements = Enumerable.Range(minValue, maxValue).ToArray();
            elementsPerRow = constructorParametersCount;
            vector = new object[elementsPerRow];
            staticExprCount = expressionsCount;
            expressionType = type;

            this.GenerateVariation(index: 0);
            
            return allExpressions;
        }

        private void GenerateVariation(int index)
        {
            if (staticExprCount == 0)
            {
                return;
            }

            if (index == elementsPerRow)
            {
                staticExprCount--;
                var instance = this.factory.GetInstance(expressionType, vector);

                allExpressions.Add(instance);
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    vector[index] = elements[i];
                    GenerateVariation(index + 1);
                }
            }
        }

        private int GetConstructorParametersCount(Type type)
        {
            var paramsCount = type
                .GetConstructors()
                .Where(ci => ci.GetParameters()
                    .All(pi => pi.ParameterType.IsNumeric()))
                .Select(ci => new
                {
                    Constructor = ci,
                    ParametersCount = ci.GetParameters().Count()
                })
                .Max(a => a.ParametersCount);

            return paramsCount;
        }
    }
}
