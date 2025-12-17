using System.ComponentModel.DataAnnotations;

namespace TradeScope.Domain.Models
{
    public sealed class AssetModel
    {
        public AssetItemModel[] Assets { get; set; } = default!;
    }

    public sealed class AssetItemModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Asset is required.")]
        public string Asset { get; set; } = default!;

        [Required(ErrorMessage = "Type is required.")]
        public string Type { get; set; } = default!;

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "Source is required.")]
        public string Source { get; set; } = default!;

        public string Endpoint { get; set; } = default!;
    }
}
