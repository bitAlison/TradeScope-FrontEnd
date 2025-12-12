using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

using TradeScope.Domain.Models;

namespace TradeScope.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var vm = new DashboardViewModel
            {
                DailyPnL = 1350.00m,
                DailyReturnPercent = 4.8,
                DailyTarget = 800.00m,
                TradesToday = 3,

                WeeklyWinRate = 76.9,
                CurrentPattern = "10x3",
                WinsLast50 = 38,
                LossesLast50 = 12,

                RiskPerTradePercent = 0.5,
                RiskPerTradeAmount = 100.00m,
                MaxDailyRisk = 400.00m,
                MaxDailyTrades = 4,
                PhaseLabel = "Fase 1 · Agressivo",

                CurrentCapital = 20000.00m,
                MonthlyWithdrawalTarget = 3500.00m,

                Assets = 
                {
                    new ()
                    {
                        Name = "Mini-índice (WIN)",
                        Meta = "> 400 pontos",
                        TotalPoints = 620,
                        WinRate = 78
                    },
                    new ()
                    {
                        Name = "Dólar (WDO)",
                        Meta = "> 14 pontos",
                        TotalPoints = 21,
                        WinRate = 72
                    },
                    new ()
                    {
                        Name = "Nasdaq (US100)",
                        Meta = "> 70 pontos",
                        TotalPoints = 112,
                        WinRate = 74
                    }
                },
                RecentOperations =
                [
                    new ()
                    {
                        Date = DateTime.Today,
                        Asset = "WIN",
                        Phase = 1,
                        Contracts = 2,
                        Result = TradeResult.Win,
                        Points = 420,
                        Pattern10x = "10x3"
                    },
                    new ()
                    {
                        Date = DateTime.Today,
                        Asset = "WDO",
                        Phase = 1,
                        Contracts = 1,
                        Result = TradeResult.Loss,
                        Points = -16,
                        Pattern10x = "10x4"
                    },
                    new ()
                    {
                        Date = DateTime.Today,
                        Asset = "US100",
                        Phase = 1,
                        Contracts = 1,
                        Result = TradeResult.Win,
                        Points = 82,
                        Pattern10x = "10x3"
                    }
                ]
            };

            return View(vm);
        }

        public IActionResult Dashboard()
        {
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
