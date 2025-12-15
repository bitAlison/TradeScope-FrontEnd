using System.ComponentModel.DataAnnotations;

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
        [Range(1, int.MaxValue, ErrorMessage = "Strategy Number is required must be at least 1")]
        public int StrategyNumber { get; set; } = default!;

        /// <summary>
        /// Strategy Description
        /// </summary>
        [Required(ErrorMessage = "Strategy Description is required")]
        public string StrategyDescription { get; set; } = default!;

        /// <summary>
        /// Maximum Trades per Day
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Max Trades per Day must be at least 1")]
        public int MaxTradesPerDay { get; set; } = default!;

        /// <summary>
        /// Maximum Trades per Week
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Max Trades per Week must be at least 1")]
        public int MaxTradesPerWeek { get; set; } = default!;

        /// <summary>
        /// Maximum Trades per Month
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Max Trades per Month must be at least 1")]
        public int MaxTradesPerMonth { get; set; } = default!;
    }
}
