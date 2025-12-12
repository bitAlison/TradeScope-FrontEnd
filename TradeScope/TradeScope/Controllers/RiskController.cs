using Microsoft.AspNetCore.Mvc;

using TradeScope.Domain.Models;
using TradeScope.Domain.Services.Contracts;

namespace TradeScope.Controllers
{
    public class RiskController : Controller
    {
        private readonly IRiskCalculator _riskCalculator;
        private readonly ISettingsService _settingsService;

        public RiskController(
            IRiskCalculator riskCalculator,
            ISettingsService settingsService)
        {
            _riskCalculator = riskCalculator;
            _settingsService = settingsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userId = User.Identity?.Name ?? "default";

            // Recupera parâmetros de risco a partir de Settings
            RiskParameters riskParams = _settingsService.GetRiskParameters(userId);

            // Calcula o modelo de risco
            RiskViewModel vm = _riskCalculator.Calculate(riskParams);

            return View(vm);
        }
    }
}
