using TradeScope.Domain.Models;

namespace TradeScope.Domain.Services.Contracts
{
    public interface ITradeMetricsService
    {
        Task<DashboardViewModel> BuildDashboardAsync(DateTime? now = null, CancellationToken ct = default);
    }
}
