using TradeScope.Domain.Models;
using TradeScope.Domain.Services.Contracts;

namespace TradeScope.Services
{
    public class SettingsService : ISettingsService
    {
        public RiskParameters GetRiskParameters(string userId)
        {
            return default!;
        }

        public SettingsViewModel GetSettings(string userId)
        {
            return default!;
        }

        public void SaveSettings(string userId, SettingsViewModel settings)
        {
            
        }
    }
}
