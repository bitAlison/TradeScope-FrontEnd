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
        public int AssetId { get; set; } = default!;

        /// <summary>
        /// Assest's Name
        /// </summary>
        public string AssetName { get; set; } = default!;

        /// <summary>
        /// Assest's Description
        /// </summary>
        public string AssetDescription { get; set; } = default!;

        /// <summary>
        /// Target Point per Trade
        /// </summary>
        public int TargetPointPerTrade { get; set; } = default!;
    }
}
