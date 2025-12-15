using System.ComponentModel.DataAnnotations;

namespace TradeScope.Domain.Models
{
    /// <summary>
    /// General Settings
    /// </summary>
    public sealed class SettingsViewModel
    {
        /// <summary>
        /// Initial Capital of investment
        /// </summary>
        [Range(0.1, double.MaxValue, ErrorMessage = "Initial Capital must be at least 0.1%")]
        public decimal InitialCapital { get; set; } = default!;

        /// <summary>
        /// Cal os Risk Per Trade Percent (Initial Capital + Phase Trade + Asset Tagert Point)
        /// </summary>
        [Range(0.0001, double.MaxValue, ErrorMessage = "Risk Per Trade Percent must be at least 0.0001%")]
        public double RiskPerTradePercent { get; set; } = default!;

        /// <summary>
        /// List of Phase Trade Settings
        /// </summary>
        //[Required(ErrorMessage = "At least one Strategy Phase Trade setting is required")]
        public List<StrategyPhaseTradeSettings> StrategyPhaseTrade { get; set; } = default!;

        /// <summary>
        /// List of Point Targets of Assets
        /// </summary>
       // [Required(ErrorMessage = "At least one Asset Target Point setting is required")]
        public List<AssetTargetPointsSettings> AssetTargetPoint { get; set; } = default!;

        /// <summary>
        /// Withdrawl Settings
        /// </summary>
        //[Required(ErrorMessage = "Withdrawl Settings are required")]
        public WithdrawlSettings Withdrawl { get; set; } = default!;
    }
}
