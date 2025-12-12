using TradeScope.Domain.Models;
using TradeScope.Domain.Services.Contracts;

namespace TradeScope.Services
{
    public class SettingsService : ISettingsService
    {
        public RiskParameters GetRiskParameters(string userId)
        {
            throw new NotImplementedException();
        }

        public SettingsViewModel GetSettings(string userId)
        {
            throw new NotImplementedException();
        }

        public void SaveSettings(string userId, SettingsViewModel settings)
        {
            throw new NotImplementedException();
        }
    }
}
