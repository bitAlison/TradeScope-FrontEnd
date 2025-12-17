using System.ComponentModel.DataAnnotations;

namespace TradeScope.Domain.Models.Dto
{
    public sealed class IndexItemModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Stock is required.")]
        public string Stock { get; set; } = default!;

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = default!;
    }
}
