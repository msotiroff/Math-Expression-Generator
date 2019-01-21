using MathExpressionGenerator.Common.Containers;
using Microsoft.AspNetCore.Mvc;

namespace MathExpressionGenerator.Web.Controllers
{
    public class LanguageController : BaseController
    {
        public LanguageController(ILanguageContainer languageContainer) 
            : base(languageContainer)
        {
        }

        [HttpPost]
        public IActionResult Change(
            string language, string returnToArea, string returnToController, string returnToAction)
        {
            base.ChangeLanguage(language);

            return RedirectToAction(
                returnToAction, returnToController, new { Area = returnToArea });
        }
    }
}