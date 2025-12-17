using System.ComponentModel.DataAnnotations;

namespace TradeScope.Domain.Models.Entities
{
    public sealed class B3StockEntity // : EntityBase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Stock is required.")]
        public string Stock { get; set; } = default!;

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "Logo is required.")]
        public string Logo { get; set; } = default!;

        [Required(ErrorMessage = "Sector is required.")]
        public string Sector { get; set; } = default!;

        [Required(ErrorMessage = "Type is required.")]
        public string Type { get; set; } = default!;
    }
}
