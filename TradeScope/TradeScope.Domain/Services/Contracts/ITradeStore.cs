using TradeScope.Domain.Models;

namespace TradeScope.Domain.Services.Contracts
{
    public interface ITradeStore
    {
        Task<TradeScopeState> LoadAsync(CancellationToken ct = default);
        Task SaveAsync(TradeScopeState state, CancellationToken ct = default);

        Task<IReadOnlyList<TradeOperation>> GetOperationsAsync(CancellationToken ct = default);
        Task AddOperationAsync(TradeOperation op, CancellationToken ct = default);
        Task DeleteOperationAsync(DateTime date, string asset, int points, int contracts, CancellationToken ct = default);

        Task<SettingsViewModel> GetSettingsAsync(CancellationToken ct = default);
        Task SaveSettingsAsync(SettingsViewModel settings, CancellationToken ct = default);
    }
}
