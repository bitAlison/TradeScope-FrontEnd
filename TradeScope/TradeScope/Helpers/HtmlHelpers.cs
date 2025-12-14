using Microsoft.AspNetCore.Mvc.Rendering;

namespace TradeScope.Helpers
{
    public static class HtmlHelpers
    {
        public static string IsActive(
            this IHtmlHelper html,
            string controller,
            string action)
        {
            var routeData = html.ViewContext.RouteData;

            var currentController = routeData.Values["controller"]?.ToString();
            var currentAction = routeData.Values["action"]?.ToString();

            return controller == currentController && action == currentAction
                ? "ts-nav-item-active"
                : "";
        }
    }
}
