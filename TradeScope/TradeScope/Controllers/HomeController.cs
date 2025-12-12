using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

using TradeScope.Domain.Models;
using TradeScope.Domain.Services.Contracts;

namespace TradeScope.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITradeMetricsService _metrics;

        public HomeController(ITradeMetricsService metrics)
        {
            _metrics = metrics;
        }

        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var vm = await _metrics.BuildDashboardAsync(ct: ct);
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
