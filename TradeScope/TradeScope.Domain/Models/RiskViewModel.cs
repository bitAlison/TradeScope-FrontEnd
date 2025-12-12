namespace TradeScope.Domain.Models
{
    public class RiskViewModel
    {
        public decimal Capital { get; set; }
        public double RiskPerTradePercent { get; set; }
        public decimal RiskPerTradeAmount { get; set; }
        public int TradesPerDay { get; set; }
        public decimal MaxDailyRiskAmount { get; set; }

        public double ExpectedEvPerTradePercent { get; set; }
        public double ExpectedMonthlyGrowthPercent { get; set; }
        public decimal ExpectedMonthlyGrowthAmount { get; set; }

        public string PhaseLabel { get; set; } = string.Empty;
        public int TradesPerMonth { get; set; } = default!;
    }
}
