using Microsoft.AspNetCore.Mvc.Rendering;

namespace TradeScope.Domain.Extensions
{
    public static class SelectListHelper
    {
        public static List<SelectListItem> GetEnumOptions<TEnum>(TEnum? selected = null)
            where TEnum : struct, Enum
        {
            return [.. Enum.GetValues<TEnum>()
                .Cast<TEnum>()
                .Select(v =>
                {
                    var enumValue = (Enum)(object)v;

                    return new SelectListItem
                    {
                        Text = enumValue.GetDescription(),

                        // Opção A (recomendada): salvar o NOME do enum
                        Value = v.ToString(),

                        // Marcar selecionado quando necessário
                        Selected = selected.HasValue && EqualityComparer<TEnum>.Default.Equals(v, selected.Value)
                    };
                })];
        }
    }
}
