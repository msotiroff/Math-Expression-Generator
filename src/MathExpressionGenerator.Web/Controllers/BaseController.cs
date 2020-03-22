using MathExpressionGenerator.Common.Containers;
using MathExpressionGenerator.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace MathExpressionGenerator.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly ILanguageContainer languageContainer;

        public BaseController(ILanguageContainer languageContainer)
        {
            this.languageContainer = languageContainer;
        }

        internal void ChangeLanguage(string language)
        {
            this.HttpContext.SetLanguageToCookie(language);
        }
    }
}