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
                    WithdrawlFrequency = WithdrawlFrequency.StartAfterFirstMonth
                }
            };

            return View(vm);
        }
    }
}
