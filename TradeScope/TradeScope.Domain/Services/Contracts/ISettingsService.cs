using TradeScope.Domain.Models;

namespace TradeScope.Domain.Services.Contracts
{
    public interface ISettingsService
    {
        SettingsViewModel GetSettings(string userId);
        void SaveSettings(string userId, SettingsViewModel settings);
        RiskParameters GetRiskParameters(string userId);
    }
}
