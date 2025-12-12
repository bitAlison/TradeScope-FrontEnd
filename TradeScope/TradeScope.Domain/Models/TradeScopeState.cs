namespace TradeScope.Domain.Models
{
    public sealed class TradeScopeState
    {
        public SettingsViewModel Settings { get; set; } = new SettingsViewModel
        {
            InitialCapital = 20000m,
            RiskPerTradePercent = 1.0,
            Phase1TradesPerDay = 5,
            Phase2TradesPerDay = 4,
            Phase3TradesPerDay = 3,
            WinTargetPoints = 400,
            DolarTargetPoints = 14,
            NasdaqTargetPoints = 70,
            Month2Withdrawal = 1800m,
            WithdrawalIncrement = 200m,
            MaxWithdrawal = 3500m
        };

        public List<TradeOperation> Operations { get; set; } = new();
    }
}
