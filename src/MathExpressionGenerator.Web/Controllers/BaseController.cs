using MathExpressionGenerator.Common.Containers;
using MathExpressionGenerator.Common.Languages;
using Microsoft.AspNetCore.Mvc;

namespace MathExpressionGenerator.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly ILanguageContainer languageContainer;

        public BaseController(ILanguageContainer languageContainer)
        {
            this.languageContainer = languageContainer;
            this.EnsureLanguageInitialized();
        }

        public static ILanguage CurrentLanguage { get; private set; }

        internal void ChangeLanguage(string language)
        {
            var newLanguage = this.languageContainer.Get(language);

            if (newLanguage != null)
            {
                CurrentLanguage = newLanguage;
            }
        }

        private void EnsureLanguageInitialized()
        {
            if (CurrentLanguage == null)
            {
                CurrentLanguage = this.languageContainer
                    .Get(typeof(EnglishLanguage));
            }
        }
    }
}