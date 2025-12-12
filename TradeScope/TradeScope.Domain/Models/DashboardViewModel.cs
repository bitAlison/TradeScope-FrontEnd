namespace TradeScope.Domain.Models
{
    public class DashboardViewModel
    {
        public decimal DailyPnL { get; set; }
        public double DailyReturnPercent { get; set; }
        public decimal DailyTarget { get; set; }
        public int TradesToday { get; set; }

        public double WeeklyWinRate { get; set; }
        public string CurrentPattern { get; set; } = string.Empty;
        public int WinsLast50 { get; set; }
        public int LossesLast50 { get; set; }

        public double RiskPerTradePercent { get; set; }
        public decimal RiskPerTradeAmount { get; set; }
        public decimal MaxDailyRisk { get; set; }
        public int MaxDailyTrades { get; set; }
        public string PhaseLabel { get; set; } = string.Empty;

        public decimal CurrentCapital { get; set; }
        public decimal MonthlyWithdrawalTarget { get; set; }

        public List<AssetPerformance> Assets { get; set; } = [];
        public List<TradeOperation> RecentOperations { get; set; } = [];
    }
}
