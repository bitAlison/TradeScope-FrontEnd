using TradeScope.Domain.Models;
using TradeScope.Domain.Services.Contracts;

namespace TradeScope.Services
{
    public sealed class TradeMetricsService : ITradeMetricsService
    {
        private readonly ITradeStore _store;

        // TEMP: until we model instrument-specific point value (R$/point)
        private const decimal DefaultMoneyPerPoint = 1m;

        public TradeMetricsService(ITradeStore store)
        {
            _store = store;
        }

        public async Task<DashboardViewModel> BuildDashboardAsync(DateTime? now = null, CancellationToken ct = default)
        {
            var clock = (now ?? DateTime.Now).Date;
            var settings = await _store.GetSettingsAsync(ct);
            var ops = (await _store.GetOperationsAsync(ct)).OrderBy(o => o.Date).ToList();

            decimal totalPnl = ops.Sum(SignedPointsMoney);
            var currentCapital = settings.InitialCapital + totalPnl;

            // Today's ops
            var todaysOps = ops.Where(o => o.Date.Date == clock).ToList();
            var dailyPnl = todaysOps.Sum(SignedPointsMoney);
            var dailyReturn = currentCapital == 0 ? 0 : (double)(dailyPnl / currentCapital * 100m);

            // Weekly stats (last 7 days)
            var weekStart = clock.AddDays(-6);
            var weekOps = ops.Where(o => o.Date.Date >= weekStart && o.Date.Date <= clock).ToList();
            var weeklyWinRate = weekOps.Count == 0 ? 0 : weekOps.Count(o => o.Result == TradeResult.Win) * 100.0 / weekOps.Count;

            // Last 50
            var last50 = ops.OrderByDescending(o => o.Date).Take(50).ToList();
            var wins50 = last50.Count(o => o.Result == TradeResult.Win);
            var loss50 = last50.Count(o => o.Result == TradeResult.Loss);

            // Pattern: concatenate last 10 results into 10x scale-like string (e.g., 10x7)
            var last10 = ops.OrderByDescending(o => o.Date).Take(10).ToList();
            var last10Wins = last10.Count(o => o.Result == TradeResult.Win);
            var scale = last10.Count == 0 ? 0 : last10Wins; // 0..10
            if (scale > 9) scale = 9;
            var currentPattern = $"10x{scale}";

            // Phase
            var phase = GetPhase(currentCapital);
            var phaseLabel = phase switch
            {
                1 => "Phase 1 · Aggressive",
                2 => "Phase 2 · Moderate",
                _ => "Phase 3 · Conservative"
            };

            var maxDailyTrades = phase switch
            {
                1 => settings.Phase1TradesPerDay,
                2 => settings.Phase2TradesPerDay,
                _ => settings.Phase3TradesPerDay
            };

            var riskPerTradeAmount = currentCapital * (decimal)(settings.RiskPerTradePercent / 100.0);
            var maxDailyRisk = riskPerTradeAmount * maxDailyTrades;

            // Withdrawal target (simplified: current configured step)
            var monthlyWithdrawalTarget = settings.Month2Withdrawal;

            // Daily target: pay the withdrawal plus grow, simplified to withdrawal/20
            var dailyTarget = monthlyWithdrawalTarget / 20m;

            // Asset summary
            var assets = ops
                .GroupBy(o => o.Asset)
                .Select(g =>
                {
                    var totalPoints = g.Sum(o => SignedPoints(o) * o.Contracts);
                    var winRate = g.Count() == 0 ? 0 : g.Count(o => o.Result == TradeResult.Win) * 100.0 / g.Count();
                    return new AssetPerformance
                    {
                        Name = g.Key,
                        Meta = GetAssetMeta(g.Key, settings),
                        TotalPoints = totalPoints,
                        WinRate = winRate
                    };
                })
                .OrderByDescending(a => a.TotalPoints)
                .ToList();

            var recentOps = ops.OrderByDescending(o => o.Date).Take(12).ToList();

            return new DashboardViewModel
            {
                DailyPnL = dailyPnl,
                DailyReturnPercent = dailyReturn,
                DailyTarget = dailyTarget,
                TradesToday = todaysOps.Count,

                WeeklyWinRate = weeklyWinRate,
                CurrentPattern = currentPattern,
                WinsLast50 = wins50,
                LossesLast50 = loss50,

                RiskPerTradePercent = settings.RiskPerTradePercent,
                RiskPerTradeAmount = riskPerTradeAmount,
                MaxDailyRisk = maxDailyRisk,
                MaxDailyTrades = maxDailyTrades,
                PhaseLabel = phaseLabel,

                CurrentCapital = currentCapital,
                MonthlyWithdrawalTarget = monthlyWithdrawalTarget,

                Assets = assets,
                RecentOperations = recentOps
            };
        }

        private static int GetPhase(decimal capital)
        {
            if (capital < 30000m) return 1;
            if (capital < 60000m) return 2;
            return 3;
        }

        private static int SignedPoints(TradeOperation o) => o.Result == TradeResult.Win ? o.Points : -o.Points;

        private static decimal SignedPointsMoney(TradeOperation o)
        {
            var signed = SignedPoints(o);
            return signed * o.Contracts * DefaultMoneyPerPoint;
        }

        private static string GetAssetMeta(string asset, SettingsViewModel settings)
        {
            // Show the objective points per operation for each main asset.
            // Asset names come from UI; keep flexible.
            var a = asset.Trim().ToLowerInvariant();
            if (a.Contains("mini") || a.Contains("índice") || a.Contains("indice"))
                return $">{settings.WinTargetPoints} pts";
            if (a.Contains("dólar") || a.Contains("dolar") || a.Contains("usd"))
                return $">{settings.DolarTargetPoints} pts";
            if (a.Contains("nasdaq") || a.Contains("nq"))
                return $">{settings.NasdaqTargetPoints} pts";
            return "—";
        }
    }
}
