using System.ComponentModel.DataAnnotations;

namespace TradeScope.Domain.Models
{
    /// <summary>
    /// Asset Target Point
    /// </summary>
    public sealed class AssetTargetPointsSettings
    {
        /// <summary>
        /// Asset's Identification
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Asset ID is required must be at least 1")]
        public int AssetId { get; set; } = default!;

        /// <summary>
        /// Assest's Name
        /// </summary>
        [Required(ErrorMessage = "Asset Name is required")]
        public string AssetName { get; set; } = default!;

        /// <summary>
        /// Assest's Description
        /// </summary>
        [Required(ErrorMessage = "Asset Description is required")]
        public string AssetDescription { get; set; } = default!;

        /// <summary>
        /// Target Point per Trade
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Target Point per Trade must be at least 1")]
        public int TargetPointPerTrade { get; set; } = default!;
    }
}
