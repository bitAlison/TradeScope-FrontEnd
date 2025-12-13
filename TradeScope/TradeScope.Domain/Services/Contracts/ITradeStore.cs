using TradeScope.Domain.Models;

namespace TradeScope.Domain.Services.Contracts
{
    public interface ITradeStore
    {
        Task<TradeScopeState> LoadAsync(CancellationToken ct = default);
        Task SaveAsync(TradeScopeState state, CancellationToken ct = default);
    }
}
