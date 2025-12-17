using System.ComponentModel.DataAnnotations;

namespace TradeScope.Domain.Models.Entities
{
    public sealed class ForexEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Currency is required.")]
        public string Currency { get; set; } = default!;

        [Required(ErrorMessage = "Pair is required.")]
        public string Pair { get; set; } = default!;
    }
}
