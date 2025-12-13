using Microsoft.AspNetCore.Mvc;
using TradeScope.Domain.Services.Contracts;

namespace TradeScope.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITradeStore _store;
        private readonly ITradeMetricsService _metrics;

        public HomeController(ITradeStore store, ITradeMetricsService metrics)
        {
            _store = store;
            _metrics = metrics;
        }

        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var state = await _store.LoadAsync(ct);
            var vm = _metrics.BuildDashboard(state, DateTime.Now);
            return View(vm);
        }
    }
}
