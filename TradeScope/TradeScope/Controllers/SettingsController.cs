using Microsoft.AspNetCore.Mvc;

using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

using TradeScope.Domain.Extensions;
using TradeScope.Domain.Models;
using TradeScope.Helpers;

namespace TradeScope.Controllers
{
    public class SettingsController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public SettingsController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            /*
            var vm = new SettingsViewModel()
            {
                AssetTargetPoint = [],
                StrategyPhaseTrade = [],
                Withdrawl = new WithdrawlSettings()
                {
                    WithdrawlFrequencyOptions = SelectListHelper.GetEnumOptions<WithdrawlFrequency>()
                }
            };
            /*/
            var vm = new SettingsViewModel
            {
                InitialCapital = 20000m,
                RiskPerTradePercent = 0.5,
                StrategyPhaseTrade = [
                
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =1,
                            StrategyDescription = "Extreme",
                            MaxTradesPerDay = 6,
                            MaxTradesPerWeek = 30,
                            MaxTradesPerMonth = 120
                        },
                        new StrategyPhaseTradeSettings { 
                            StrategyNumber =2, 
                            StrategyDescription = "Agressive", 
                            MaxTradesPerDay = 5,
                            MaxTradesPerWeek = 25,
                            MaxTradesPerMonth = 100
                        },
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =3,
                            StrategyDescription = "Moderate",
                            MaxTradesPerDay = 3,
                            MaxTradesPerWeek = 15,
                            MaxTradesPerMonth = 60
                        },
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =4,
                            StrategyDescription = "Conservative",
                            MaxTradesPerDay = 2,
                            MaxTradesPerWeek = 10,
                            MaxTradesPerMonth = 40
                        },
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =5,
                            StrategyDescription = "Ultra Conservative",
                            MaxTradesPerDay = 1,
                            MaxTradesPerWeek = 5,
                            MaxTradesPerMonth = 20
                        },
                           new StrategyPhaseTradeSettings {
                            StrategyNumber =1,
                            StrategyDescription = "Extreme",
                            MaxTradesPerDay = 6,
                            MaxTradesPerWeek = 30,
                            MaxTradesPerMonth = 120
                        },
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =2,
                            StrategyDescription = "Agressive",
                            MaxTradesPerDay = 5,
                            MaxTradesPerWeek = 25,
                            MaxTradesPerMonth = 100
                        },
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =3,
                            StrategyDescription = "Moderate",
                            MaxTradesPerDay = 3,
                            MaxTradesPerWeek = 15,
                            MaxTradesPerMonth = 60
                        },
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =4,
                            StrategyDescription = "Conservative",
                            MaxTradesPerDay = 2,
                            MaxTradesPerWeek = 10,
                            MaxTradesPerMonth = 40
                        },
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =5,
                            StrategyDescription = "Ultra Conservative",
                            MaxTradesPerDay = 1,
                            MaxTradesPerWeek = 5,
                            MaxTradesPerMonth = 20
                        },
                           new StrategyPhaseTradeSettings {
                            StrategyNumber =1,
                            StrategyDescription = "Extreme",
                            MaxTradesPerDay = 6,
                            MaxTradesPerWeek = 30,
                            MaxTradesPerMonth = 120
                        },
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =2,
                            StrategyDescription = "Agressive",
                            MaxTradesPerDay = 5,
                            MaxTradesPerWeek = 25,
                            MaxTradesPerMonth = 100
                        },
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =3,
                            StrategyDescription = "Moderate",
                            MaxTradesPerDay = 3,
                            MaxTradesPerWeek = 15,
                            MaxTradesPerMonth = 60
                        },
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =4,
                            StrategyDescription = "Conservative",
                            MaxTradesPerDay = 2,
                            MaxTradesPerWeek = 10,
                            MaxTradesPerMonth = 40
                        },
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =5,
                            StrategyDescription = "Ultra Conservative",
                            MaxTradesPerDay = 1,
                            MaxTradesPerWeek = 5,
                            MaxTradesPerMonth = 20
                        },
                           new StrategyPhaseTradeSettings {
                            StrategyNumber =1,
                            StrategyDescription = "Extreme",
                            MaxTradesPerDay = 6,
                            MaxTradesPerWeek = 30,
                            MaxTradesPerMonth = 120
                        },
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =2,
                            StrategyDescription = "Agressive",
                            MaxTradesPerDay = 5,
                            MaxTradesPerWeek = 25,
                            MaxTradesPerMonth = 100
                        },
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =3,
                            StrategyDescription = "Moderate",
                            MaxTradesPerDay = 3,
                            MaxTradesPerWeek = 15,
                            MaxTradesPerMonth = 60
                        },
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =4,
                            StrategyDescription = "Conservative",
                            MaxTradesPerDay = 2,
                            MaxTradesPerWeek = 10,
                            MaxTradesPerMonth = 40
                        },
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =5,
                            StrategyDescription = "Ultra Conservative",
                            MaxTradesPerDay = 1,
                            MaxTradesPerWeek = 5,
                            MaxTradesPerMonth = 20
                        },
                           new StrategyPhaseTradeSettings {
                            StrategyNumber =1,
                            StrategyDescription = "Extreme",
                            MaxTradesPerDay = 6,
                            MaxTradesPerWeek = 30,
                            MaxTradesPerMonth = 120
                        },
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =2,
                            StrategyDescription = "Agressive",
                            MaxTradesPerDay = 5,
                            MaxTradesPerWeek = 25,
                            MaxTradesPerMonth = 100
                        },
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =3,
                            StrategyDescription = "Moderate",
                            MaxTradesPerDay = 3,
                            MaxTradesPerWeek = 15,
                            MaxTradesPerMonth = 60
                        },
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =4,
                            StrategyDescription = "Conservative",
                            MaxTradesPerDay = 2,
                            MaxTradesPerWeek = 10,
                            MaxTradesPerMonth = 40
                        },
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =5,
                            StrategyDescription = "Ultra Conservative",
                            MaxTradesPerDay = 1,
                            MaxTradesPerWeek = 5,
                            MaxTradesPerMonth = 20
                        },
                           new StrategyPhaseTradeSettings {
                            StrategyNumber =1,
                            StrategyDescription = "Extreme",
                            MaxTradesPerDay = 6,
                            MaxTradesPerWeek = 30,
                            MaxTradesPerMonth = 120
                        },
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =2,
                            StrategyDescription = "Agressive",
                            MaxTradesPerDay = 5,
                            MaxTradesPerWeek = 25,
                            MaxTradesPerMonth = 100
                        },
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =3,
                            StrategyDescription = "Moderate",
                            MaxTradesPerDay = 3,
                            MaxTradesPerWeek = 15,
                            MaxTradesPerMonth = 60
                        },
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =4,
                            StrategyDescription = "Conservative",
                            MaxTradesPerDay = 2,
                            MaxTradesPerWeek = 10,
                            MaxTradesPerMonth = 40
                        },
                        new StrategyPhaseTradeSettings {
                            StrategyNumber =5,
                            StrategyDescription = "Ultra Conservative",
                            MaxTradesPerDay = 1,
                            MaxTradesPerWeek = 5,
                            MaxTradesPerMonth = 20
                        },
                ],
                AssetTargetPoint =
                [
                    new AssetTargetPointsSettings
                    {
                         AssetId = 1,
                         AssetName = "Stocks",
                        AssetDescription = "Equity Shares",
                         TargetPointPerTrade = 10
                    },
                    new AssetTargetPointsSettings
                    {
                         AssetId = 2,
                         AssetName = "Forex",
                        AssetDescription = "Foreign Exchange",
                         TargetPointPerTrade = 15
                    },
                    new AssetTargetPointsSettings
                    {
                         AssetId = 3,
                         AssetName = "Commodities",
                        AssetDescription = "Raw Materials",
                         TargetPointPerTrade = 20
                    },
                    new AssetTargetPointsSettings
                    {
                         AssetId = 4,
                         AssetName = "Cryptocurrency",
                        AssetDescription = "Digital Currency",
                         TargetPointPerTrade = 25
                    },
                    new AssetTargetPointsSettings
                    {
                         AssetId = 5,
                         AssetName = "Indices",
                        AssetDescription = "Market Indexes",
                         TargetPointPerTrade = 30
                    },
                    new AssetTargetPointsSettings
                    {
                         AssetId = 6,
                         AssetName = "ETFs",
                        AssetDescription = "Exchange Traded Funds",
                         TargetPointPerTrade = 12
                    },
                    new AssetTargetPointsSettings
                    {
                         AssetId = 1,
                         AssetName = "Stocks",
                        AssetDescription = "Equity Shares",
                         TargetPointPerTrade = 10
                    },
                    new AssetTargetPointsSettings
                    {
                         AssetId = 2,
                         AssetName = "Forex",
                        AssetDescription = "Foreign Exchange",
                         TargetPointPerTrade = 15
                    },
                    new AssetTargetPointsSettings
                    {
                         AssetId = 3,
                         AssetName = "Commodities",
                        AssetDescription = "Raw Materials",
                         TargetPointPerTrade = 20
                    },
                    new AssetTargetPointsSettings
                    {
                         AssetId = 4,
                         AssetName = "Cryptocurrency",
                        AssetDescription = "Digital Currency",
                         TargetPointPerTrade = 25
                    },
                    new AssetTargetPointsSettings
                    {
                         AssetId = 5,
                         AssetName = "Indices",
                        AssetDescription = "Market Indexes",
                         TargetPointPerTrade = 30
                    },
                    new AssetTargetPointsSettings
                    {
                         AssetId = 6,
                         AssetName = "ETFs",
                        AssetDescription = "Exchange Traded Funds",
                         TargetPointPerTrade = 12
                    },
                    new AssetTargetPointsSettings
                    {
                         AssetId = 1,
                         AssetName = "Stocks",
                        AssetDescription = "Equity Shares",
                         TargetPointPerTrade = 10
                    },
                    new AssetTargetPointsSettings
                    {
                         AssetId = 2,
                         AssetName = "Forex",
                        AssetDescription = "Foreign Exchange",
                         TargetPointPerTrade = 15
                    },
                    new AssetTargetPointsSettings
                    {
                         AssetId = 3,
                         AssetName = "Commodities",
                        AssetDescription = "Raw Materials",
                         TargetPointPerTrade = 20
                    },
                    new AssetTargetPointsSettings
                    {
                         AssetId = 4,
                         AssetName = "Cryptocurrency",
                        AssetDescription = "Digital Currency",
                         TargetPointPerTrade = 25
                    },
                    new AssetTargetPointsSettings
                    {
                         AssetId = 5,
                         AssetName = "Indices",
                        AssetDescription = "Market Indexes",
                         TargetPointPerTrade = 30
                    },
                    new AssetTargetPointsSettings
                    {
                         AssetId = 6,
                         AssetName = "ETFs",
                        AssetDescription = "Exchange Traded Funds",
                         TargetPointPerTrade = 12
                    },
                    new AssetTargetPointsSettings
                    {
                         AssetId = 1,
                         AssetName = "Stocks",
                        AssetDescription = "Equity Shares",
                         TargetPointPerTrade = 10
                    },
                    new AssetTargetPointsSettings
                    {
                         AssetId = 2,
                         AssetName = "Forex",
                        AssetDescription = "Foreign Exchange",
                         TargetPointPerTrade = 15
                    },
                    new AssetTargetPointsSettings
                    {
                         AssetId = 3,
                         AssetName = "Commodities",
                        AssetDescription = "Raw Materials",
                         TargetPointPerTrade = 20
                    },
                    new AssetTargetPointsSettings
                    {
                         AssetId = 4,
                         AssetName = "Cryptocurrency",
                        AssetDescription = "Digital Currency",
                         TargetPointPerTrade = 25
                    },
                    new AssetTargetPointsSettings
                    {
                         AssetId = 5,
                         AssetName = "Indices",
                        AssetDescription = "Market Indexes",
                         TargetPointPerTrade = 30
                    },
                    new AssetTargetPointsSettings
                    {
                         AssetId = 6,
                         AssetName = "ETFs",
                        AssetDescription = "Exchange Traded Funds",
                         TargetPointPerTrade = 12
                    },
                ],
                Withdrawl = new WithdrawlSettings
                {
                    EstimateWithdrawalPerWeek = 500m,
                    EstimateIncrementWithdrawalPerWeek = 50m,
                    EstimateWithdrawalPerMonth = 2000m,
                    EstimateIncrementWithdrawalPerMonth = 200m,
                    MaxWithdrawalPerMonth = 5000m,
                    WithdrawlFrequency = WithdrawlFrequency.StartAfterFirstMonth,
                    WithdrawlFrequencyOptions = SelectListHelper.GetEnumOptions<WithdrawlFrequency>()
                }
            };
            //*/

            return View(vm);
        }

        [HttpGet]
        public IActionResult Save() => RedirectToAction("Index");

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(SettingsViewModel model, string? settingsJson)
        {
            // Se quiser forçar validação do Model:
            if (!ModelState.IsValid)
            {
                ViewData["ReturnUrl"] = Url.Action("Index", "Settings");
                model.Withdrawl.WithdrawlFrequencyOptions = SelectListHelper.GetEnumOptions<WithdrawlFrequency>();
                return View("Index", model);
            }

            // Preferência: se o JS mandou o JSON, salva ele (espelha exatamente o que a tela montou).
            // Caso contrário, serializa o model bindado.
            string jsonToPersist;

            if (!string.IsNullOrWhiteSpace(settingsJson))
            {
                // Valida se é JSON válido antes de salvar (evita salvar lixo)
                using var _ = JsonDocument.Parse(settingsJson);
                jsonToPersist = JsonHelpers.PrettyJson(settingsJson);
            }
            else
            {
                jsonToPersist = JsonSerializer.Serialize(model, JsonHelpers.JsonOptions());
            }

            var dir = Path.Combine(_env.ContentRootPath, "App_Data", "settings");
            Directory.CreateDirectory(dir);

            // Nome do arquivo: ajuste conforme sua regra (por usuário, por ambiente, etc.)
            var filePath = Path.Combine(dir, "tradescope.settings.json");

            // Escrita atômica (evita arquivo corrompido em caso de crash)
            var tmp = filePath + ".tmp";
            System.IO.File.WriteAllText(tmp, jsonToPersist, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
            System.IO.File.Move(tmp, filePath, overwrite: true);

            // Fluxo pós-save: redireciona para Index (ou retorne Ok/Json se for AJAX)
            return RedirectToAction("Index");
        }
    }
}
