using TradeScope.Domain.Models;

namespace TradeScope.Domain.Services.Contracts
{
    public interface ITradeMetricsService
    {
        DashboardViewModel BuildDashboard(TradeScopeState state, DateTime now);
    }
}
