//using Microsoft.AspNetCore.Mvc.Rendering;

namespace TradeScope.Localization
{
    public interface ITranslationService
    {
        string this[string key] { get; }

        //List<SelectListItem> GetEnumOptions<T>(T? selected = null) where T : struct, Enum;
    }
}
