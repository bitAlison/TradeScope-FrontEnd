using TradeScope.Domain.Models;
using TradeScope.Domain.Services.Contracts;

namespace TradeScope.Services
{
    public class TradeMetricsService : ITradeMetricsService
    {
        public DashboardViewModel BuildDashboard(TradeScopeState state, DateTime now)
        {
            var ops = state.Operations ?? new List<TradeOperation>();
            var today = now.Date;

            var opsToday = ops.Where(o => o.Date.Date == today).ToList();
            var dailyPoints = opsToday.Sum(o => o.Points);

            // Observação: ainda não temos "valor por ponto" definido no sistema.
            // Então, por enquanto, PnL = Points (mantém consistência com metas por pontos).
            // Quando você definir "R$/ponto" por ativo, a gente converte.
            var dailyPnL = (decimal)dailyPoints;

            var capital = state.CurrentCapital;
            var dailyReturn = capital == 0 ? 0 : (double)(dailyPnL / capital * 100);

            // Last 50
            var last50 = ops.OrderByDescending(o => o.Date).Take(50).ToList();
            var wins50 = last50.Count(o => o.Result == TradeResult.Win);
            var losses50 = last50.Count(o => o.Result == TradeResult.Loss);

            // Weekly win rate: últimos 7 dias (inclui hoje)
            var from7 = today.AddDays(-6);
            var last7 = ops.Where(o => o.Date.Date >= from7 && o.Date.Date <= today).ToList();
            var last7Total = last7.Count;
            var last7Wins = last7.Count(o => o.Result == TradeResult.Win);
            var weeklyWinRate = last7Total == 0 ? 0 : (double)last7Wins / last7Total * 100;

            // Assets aggregation
            var assets = ops
                .GroupBy(o => o.Asset ?? "-")
                .Select(g =>
                {
                    var total = g.Count();
                    var wins = g.Count(x => x.Result == TradeResult.Win);
                    var wr = total == 0 ? 0 : (double)wins / total * 100;

                    return new AssetPerformance
                    {
                        Name = g.Key,
                        Meta = "-", // depois ligamos nas metas do Settings
                        TotalPoints = g.Sum(x => x.Points),
                        WinRate = wr
                    };
                })
                .OrderByDescending(a => a.WinRate)
                .ToList();

            return new DashboardViewModel
            {
                CurrentCapital = capital,

                DailyPnL = dailyPnL,
                DailyReturnPercent = dailyReturn,
                TradesToday = opsToday.Count,

                WeeklyWinRate = weeklyWinRate,
                WinsLast50 = wins50,
                LossesLast50 = losses50,

                Assets = assets,
                RecentOperations = ops.OrderByDescending(o => o.Date).Take(15).ToList(),

                // Estes campos dependem de Settings (depois conectamos):
                DailyTarget = 0,
                CurrentPattern = last50.FirstOrDefault()?.Pattern10x ?? "-",
                RiskPerTradePercent = 0,
                RiskPerTradeAmount = 0,
                MaxDailyTrades = 0,
                MaxDailyRisk = 0,
                MonthlyWithdrawalTarget = 0,
                PhaseLabel = "-"
            };
        }
    }
}
