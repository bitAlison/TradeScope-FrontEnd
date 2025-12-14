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
        public decimal InitialCapital { get; set; } = default!;

        /// <summary>
        /// Cal os Risk Per Trade Percent (Initial Capital + Phase Trade + Asset Tagert Point)
        /// </summary>
        public double RiskPerTradePercent { get; set; } = default!;

        /// <summary>
        /// List of Phase Trade Settings
        /// </summary>
        public List<StrategyPhaseTradeSettings> StrategyPhaseTrade { get; set; } = default!;

        /// <summary>
        /// List of Point Targets of Assets
        /// </summary>
        public List<AssetTargetPointsSettings> AssetTargetPoint { get; set; } = default!;

        /// <summary>
        /// Withdrawl Settings
        /// </summary>
        public WithdrawlSettings Withdrawl { get; set; } = default!;
    }
}
