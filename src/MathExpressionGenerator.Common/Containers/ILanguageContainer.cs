namespace MathExpressionGenerator.Common.Containers
{
    using Languages;
    using System;
    using System.Collections.Generic;

    public interface ILanguageContainer
    {
        ILanguage Get(Type type);

        IEnumerable<ILanguage> All();
    }
}