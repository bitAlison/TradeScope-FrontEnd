using Microsoft.AspNetCore.Mvc;

using TradeScope.Domain.Models;

namespace TradeScope.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            var vm = new SettingsViewModel
            {
                InitialCapital = 20000m,
                RiskPerTradePercent = 0.5,
                Phase1TradesPerDay = 3,
                Phase2TradesPerDay = 2,
                Phase3TradesPerDay = 1,
                WinTargetPoints = 400,
                DolarTargetPoints = 14,
                NasdaqTargetPoints = 70,
                Month2Withdrawal = 1800m,
                WithdrawalIncrement = 200m,
                MaxWithdrawal = 3500m
            };

            return View(vm);
        }
    }
}
