namespace MathExpressionGenerator.Common.Containers
{
    using Languages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class LanguageContainer : ILanguageContainer
    {
        private readonly IDictionary<Type, ILanguage> languages;

        public LanguageContainer()
        {
            this.languages = new Dictionary<Type, ILanguage>();

            this.InstantiateAllLanguages();
        }

        public IEnumerable<ILanguage> All()
        {
            return this.languages.Select(l => l.Value);
        }

        public ILanguage Get(Type type)
        {
            if (this.languages.ContainsKey(type))
            {
                return this.languages[type];
            }

            throw new KeyNotFoundException(nameof(type));
        }

        public ILanguage Get(string languageName)
        {
            return this.languages
                .Values
                .FirstOrDefault(lang => lang.ToString() == languageName);
        }

        private void InstantiateAllLanguages()
        {
            Assembly
                .GetAssembly(typeof(ILanguage))
                .GetTypes()
                .Where(t => t.IsClass
                    && !t.IsAbstract
                    && typeof(ILanguage).IsAssignableFrom(t))
                .Select(t => new
                {
                    Type = t,
                    Instance = (ILanguage)Activator.CreateInstance(t)
                })
                .ToList()
                .ForEach(a => this.languages.Add(a.Type, a.Instance));
        }
    }
}
