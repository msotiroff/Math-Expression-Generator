namespace MathExpressionGenerator.Models.Factories.Implementations
{
    using System;
    using System.Linq;
    using System.Reflection;
    using MathExpressionGenerator.Models.Factories.Interfaces;
    using MathExpressionGenerator.Models.Expressions;

    public class MathExpressionFactory : IMathExpressionFactory
    {
        private const string InvalidInstanceTypeExceptionMsg = "{0} is not a valid MathExpression";

        public BaseMathExpression GetInstance(Type instanceType, params object[] arguments)
        {
            var mathExpressionType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && typeof(BaseMathExpression).IsAssignableFrom(t))
                .FirstOrDefault(t => t == instanceType)
                ?? throw new InvalidOperationException(string.Format(InvalidInstanceTypeExceptionMsg, instanceType));

            var instance = Activator.CreateInstance(mathExpressionType, arguments);

            return (BaseMathExpression)instance;
        }
    }
}
