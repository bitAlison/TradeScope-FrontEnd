using TradeScope.Domain.Models;
using TradeScope.Domain.Services.Contracts;

namespace TradeScope.Services
{
    public class InMemorySettingsService : ISettingsService
    {
        // Storage em memória por usuário
        private readonly Dictionary<string, SettingsViewModel> _storage =
            new(StringComparer.OrdinalIgnoreCase);

        public SettingsViewModel GetSettings(string userId)
        {
            if (!_storage.TryGetValue(userId, out var settings))
            {
                // Valores padrão (substituir pelos que você já usa hoje)
                settings = new SettingsViewModel
                {
                    InitialCapital = 20000m,
                    RiskPerTradePercent = 0.5,      // 0,5%
                    TradesPerDay = 5,
                    ExpectedEvPerTradePercent = 0.2, // 0,2% por trade
                    PhaseLabel = "Fase 1 · Agressivo"
                    // ... demais configs que você já tem
                };

                _storage[userId] = settings;
            }

            return settings;
        }

        public void SaveSettings(string userId, SettingsViewModel settings)
        {
            _storage[userId] = settings;
        }

        public RiskParameters GetRiskParameters(string userId)
        {
            var settings = GetSettings(userId);

            return new RiskParameters
            {
                Capital = settings.InitialCapital,
                RiskPerTradePercent = settings.RiskPerTradePercent,
                TradesPerDay = settings.TradesPerDay,
                ExpectedEvPerTradePercent = settings.ExpectedEvPerTradePercent,
                PhaseLabel = settings.PhaseLabel ?? string.Empty
            };
        }
    }
}
