using System.ComponentModel.DataAnnotations;

namespace TradeScope.Domain.Models.Dto
{
    public sealed class ForexItemModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Currency is required.")]
        public string Currency { get; set; } = default!;

        [Required(ErrorMessage = "Pair is required.")]
        public string Pair { get; set; } = default!;
    }
}
