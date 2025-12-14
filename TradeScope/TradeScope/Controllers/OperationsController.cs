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
            operations ??=
                [
                    new() {
                        Date = DateTime.Now,
                        Asset = "Sample Asset",
                        Points = 10,
                        Contracts = 1,
                        Result = TradeResult.Win
                    },
                       new() {
                        Date = DateTime.Now,
                        Asset = "Sample Asset",
                        Points = 10,
                        Contracts = 1,
                        Result = TradeResult.Win
                    },
                       new() {
                        Date = DateTime.Now,
                        Asset = "Sample Asset",
                        Points = 10,
                        Contracts = 1,
                        Result = TradeResult.Win
                    },
                       new() {
                        Date = DateTime.Now,
                        Asset = "Sample Asset",
                        Points = 10,
                        Contracts = 1,
                        Result = TradeResult.Win
                    },
                       new() {
                        Date = DateTime.Now,
                        Asset = "Sample Asset",
                        Points = 10,
                        Contracts = 1,
                        Result = TradeResult.Win
                    },
                       new() {
                        Date = DateTime.Now,
                        Asset = "Sample Asset",
                        Points = 10,
                        Contracts = 1,
                        Result = TradeResult.Win
                    },
                       new() {
                        Date = DateTime.Now,
                        Asset = "Sample Asset",
                        Points = 10,
                        Contracts = 1,
                        Result = TradeResult.Win
                    },
                       new() {
                        Date = DateTime.Now,
                        Asset = "Sample Asset",
                        Points = 10,
                        Contracts = 1,
                        Result = TradeResult.Win
                    },
                       new() {
                        Date = DateTime.Now,
                        Asset = "Sample Asset",
                        Points = 10,
                        Contracts = 1,
                        Result = TradeResult.Win
                    },
                       new() {
                        Date = DateTime.Now,
                        Asset = "Sample Asset",
                        Points = 10,
                        Contracts = 1,
                        Result = TradeResult.Win
                    },
                       new() {
                        Date = DateTime.Now,
                        Asset = "Sample Asset",
                        Points = 10,
                        Contracts = 1,
                        Result = TradeResult.Win
                    },
                       new() {
                        Date = DateTime.Now,
                        Asset = "Sample Asset",
                        Points = 10,
                        Contracts = 1,
                        Result = TradeResult.Win
                    },
                       new() {
                        Date = DateTime.Now,
                        Asset = "Sample Asset",
                        Points = 10,
                        Contracts = 1,
                        Result = TradeResult.Win
                    },
                       new() {
                        Date = DateTime.Now,
                        Asset = "Sample Asset",
                        Points = 10,
                        Contracts = 1,
                        Result = TradeResult.Win
                    },
                       new() {
                        Date = DateTime.Now,
                        Asset = "Sample Asset",
                        Points = 10,
                        Contracts = 1,
                        Result = TradeResult.Win
                    },
                       new() {
                        Date = DateTime.Now,
                        Asset = "Sample Asset",
                        Points = 10,
                        Contracts = 1,
                        Result = TradeResult.Win
                    },
                       new() {
                        Date = DateTime.Now,
                        Asset = "Sample Asset",
                        Points = 10,
                        Contracts = 1,
                        Result = TradeResult.Win
                    },
                       new() {
                        Date = DateTime.Now,
                        Asset = "Sample Asset",
                        Points = 10,
                        Contracts = 1,
                        Result = TradeResult.Win
                    },
                       new() {
                        Date = DateTime.Now,
                        Asset = "Sample Asset",
                        Points = 10,
                        Contracts = 1,
                        Result = TradeResult.Win
                    }
                ];

            var vm = new OperationsViewModel
            {
                Operations = [.. operations],
                From = from ?? DateTime.Now.AddDays(-1),
                To = to ?? DateTime.Now
            };

            return View(vm);
        }
    }
}
