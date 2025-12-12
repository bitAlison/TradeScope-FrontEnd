using Microsoft.AspNetCore.Mvc;

using TradeScope.Domain.Models;

namespace TradeScope.Controllers
{
    public class AnalyticsController : Controller
    {
        public IActionResult Index()
        {
            var assets = new List<AssetPerformance>
            {
                new ()
                {
                    Name = "Mini-índice (WIN)",
                    Meta = "> 400 pts",
                    TotalPoints = 620,
                    WinRate = 78
                },
                new ()
                {
                    Name = "Dólar (WDO)",
                    Meta = "> 14 pts",
                    TotalPoints = 21,
                    WinRate = 72
                },
                new ()
                {
                    Name = "Nasdaq (US100)",
                    Meta = "> 70 pts",
                    TotalPoints = 112,
                    WinRate = 74
                }
            };

            var vm = new AssetAnalyticsViewModel
            {
                Assets = assets,
                BestAssetName = "Mini-índice (WIN)",
                WorstAssetName = "Dólar (WDO)"
            };

            return View(vm);
        }
    }
}
