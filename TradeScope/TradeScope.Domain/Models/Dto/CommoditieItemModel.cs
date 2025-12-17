using System.ComponentModel.DataAnnotations;

namespace TradeScope.Domain.Models.Dto
{
    public sealed class CommoditieItemModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Symbol is required.")]
        public string Symbol { get; set; } = default!;

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = default!;
    }
}
