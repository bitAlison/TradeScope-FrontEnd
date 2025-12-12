namespace TradeScope.Domain.Models
{
    public class SettingsViewModel
    {
        public decimal InitialCapital { get; set; }
        public double RiskPerTradePercent { get; set; }
        public int Phase1TradesPerDay { get; set; }
        public int Phase2TradesPerDay { get; set; }
        public int Phase3TradesPerDay { get; set; }

        public int WinTargetPoints { get; set; }
        public int DolarTargetPoints { get; set; }
        public int NasdaqTargetPoints { get; set; }

        public decimal Month2Withdrawal { get; set; }
        public decimal WithdrawalIncrement { get; set; }
        public decimal MaxWithdrawal { get; set; }
    }
}
