using TradeScope.Domain.Models;

namespace TradeScope.Domain.Services.Contracts
{
    public interface IAnalyticsService
    {
        DashboardViewModel GetDashboard(string userId);
        AssetAnalyticsViewModel GetAssetAnalytics(string userId, string assetCode);
    }
}
