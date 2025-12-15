using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.Globalization;

using TradeScope.Domain.Extensions;

namespace TradeScope.Localization
{
    public class SimpleTranslationService : ITranslationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SimpleTranslationService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        //public List<SelectListItem> GetEnumOptions<T>(T? selected = null) where T : struct, Enum
        //{
        //    return [.. Enum.GetValues<T>()
        //        .Cast<T>()
        //        .Select(v =>
        //        {
        //            var enumValue = (Enum)(object)v;

        //            return new SelectListItem
        //            {
        //                Text = enumValue.GetDescription(),

        //                // Opção A (recomendada): salvar o NOME do enum
        //                Value = v.ToString(),

        //                // Marcar selecionado quando necessário
        //                Selected = selected.HasValue && EqualityComparer<T>.Default.Equals(v, selected.Value)
        //            };
        //        })];
        //}

        public string this[string key]
        {
            get
            {
                var culture = GetCurrentCultureTwoLetters();

                if (Domain.Models.TranslationModel.Translations.TryGetValue(key, out var byCulture))
                {
                    // 1) cultura atual
                    if (byCulture.TryGetValue(culture, out var text))
                        return text;

                    // 2) fallback para inglês
                    if (byCulture.TryGetValue("en", out var en))
                        return en;
                }

                // 3) fallback final: a própria chave
                return key;
            }
        }

        private string GetCurrentCultureTwoLetters()
        {
            var ctx = _httpContextAccessor.HttpContext;
            var feature = ctx?.Features.Get<IRequestCultureFeature>();
            var culture = feature?.RequestCulture.UICulture
                          ?? CultureInfo.CurrentUICulture;
            return culture.TwoLetterISOLanguageName.ToLowerInvariant();
        }
    }
}
