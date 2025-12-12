using Microsoft.AspNetCore.Mvc;

using TradeScope.Domain.Models;
using TradeScope.Domain.Services.Contracts;

namespace TradeScope.Controllers
{
    public class OperationsController : Controller
    {
        private readonly IOperationsService _operationsService;
        public OperationsController(IOperationsService operationsService)
        {
            _operationsService = operationsService;
        }

        public IActionResult Index(DateTime? from, DateTime? to)
        {
            var userId = User.Identity?.Name ?? "default";

            var operations = _operationsService.GetOperations(userId, from, to);
            var vm = new OperationsViewModel
            {
                Operations = operations.ToList(),
                From = from,
                To = to
            };

            return View(vm);
        }
    }
}
