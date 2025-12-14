namespace TradeScope.Domain.Models
{
    /// <summary>
    /// Indicadores de trade por fase
    /// </summary>
    public class StrategyPhaseTradeSettings
    {
        /// <summary>
        /// Strategy Number
        /// </summary>
        public int StrategyNumber { get; set; } = default!;

        /// <summary>
        /// Strategy Description
        /// </summary>
        public string StrategyDescription { get; set; } = default!;

        /// <summary>
        /// Maximum Trades per Day
        /// </summary>
        public int MaxTradesPerDay { get; set; } = default!;

        /// <summary>
        /// Maximum Trades per Week
        /// </summary>
        public int MaxTradesPerWeek { get; set; } = default!;

        /// <summary>
        /// Maximum Trades per Month
        /// </summary>
        public int MaxTradesPerMonth { get; set; } = default!;
    }
}
