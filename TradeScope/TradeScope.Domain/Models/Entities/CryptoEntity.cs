using System.ComponentModel.DataAnnotations;

namespace TradeScope.Domain.Models.Entities
{
    public sealed class CryptoEntity //: EntityBase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Symbol is required.")]
        public string Symbol { get; set; } = default!;

        [Required(ErrorMessage = "Name is required.")]
        public string Name{ get; set; } = default!;

    }
}
