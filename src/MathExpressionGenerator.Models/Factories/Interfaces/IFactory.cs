namespace MathExpressionGenerator.Models.Factories.Interfaces
{
    using System;

    public interface IFactory<T>
    {
        T GetInstance(Type instanceType, params object[] arguments);
    }
}
