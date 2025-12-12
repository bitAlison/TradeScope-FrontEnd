using TradeScope.Domain.Models;
using TradeScope.Domain.Services.Contracts;

namespace TradeScope.Services
{
    public class RiskCalculator : IRiskCalculator
    {
        /// <summary>
        /// Consideramos 22 dias úteis por mês como padrão.
        /// Se quiser flexibilizar, coloque isso em Settings.
        /// </summary>
        private const int TradingDaysPerMonth = 22;

        public RiskViewModel Calculate(RiskParameters parameters)
        {
            var riskPerTradeAmount = parameters.Capital * (decimal)(parameters.RiskPerTradePercent / 100.0);
            var maxDailyRiskAmount = riskPerTradeAmount * parameters.TradesPerDay;

            var tradesPerMonth = parameters.TradesPerDay * TradingDaysPerMonth;

            // EV percentual mensal aproximado (EV/trade * número de trades)
            var expectedMonthlyGrowthPercent = parameters.ExpectedEvPerTradePercent * tradesPerMonth;

            // Crescimento esperado em valor
            var expectedMonthlyGrowthAmount =
                parameters.Capital * (decimal)(expectedMonthlyGrowthPercent / 100.0);

            var riskViewModel = new RiskViewModel
            {
                Capital = parameters.Capital,
                RiskPerTradePercent = parameters.RiskPerTradePercent,
                RiskPerTradeAmount = riskPerTradeAmount,
                TradesPerDay = parameters.TradesPerDay,
                MaxDailyRiskAmount = maxDailyRiskAmount,
                ExpectedEvPerTradePercent = parameters.ExpectedEvPerTradePercent,
                ExpectedMonthlyGrowthPercent = expectedMonthlyGrowthPercent,
                ExpectedMonthlyGrowthAmount = expectedMonthlyGrowthAmount,
                PhaseLabel = parameters.PhaseLabel
            };

            return riskViewModel;
        }
    }
}