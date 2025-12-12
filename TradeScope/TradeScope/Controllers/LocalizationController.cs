using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace TradeScope.Controllers
{
    public class LocalizationController : Controller
    {
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            if (string.IsNullOrWhiteSpace(culture))
            {
                culture = "en";
            }

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(
                    new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            if (string.IsNullOrWhiteSpace(returnUrl))
                returnUrl = Url.Action("Index", "Home") ?? "/";

            return LocalRedirect(returnUrl);
        }
    }
}
