using DotNetExtensions.Common;
using MathExpressionGenerator.Common.Containers;
using MathExpressionGenerator.Common.Languages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MathExpressionGenerator.Web.Infrastructure.Extensions
{
    public static class HttpContextExtensions
    {
        public static ILanguage GetLanguageFromCookie(this HttpContext context)
        {
            var languageContainer = context.RequestServices
                .GetRequiredService<ILanguageContainer>();
            var langCookieContent = context
                .Request
                .Cookies[WebConstants.LanguageCookieName];
            var lang  = languageContainer.Get(typeof(BulgarianLanguage));

            if (langCookieContent.IsNotNullOrWhiteSpace())
            {
                lang = languageContainer.Get(langCookieContent)
                    ?? lang;

                return lang;
            }

            context.Response.Cookies.Append(
                WebConstants.LanguageCookieName,
                nameof(BulgarianLanguage),
                new CookieOptions
                {
                    Expires = DateTime.UtcNow.AddYears(1),
                    IsEssential = true,
                    HttpOnly = false
                });

            return lang;
        }

        public static void SetLanguageToCookie(this HttpContext context, string language)
        {
            context.Response.Cookies.Append(
                WebConstants.LanguageCookieName,
                language,
                new CookieOptions
                {
                    Expires = DateTime.UtcNow.AddYears(1),
                    IsEssential = true,
                    HttpOnly = false
                });
        }
    }
}
