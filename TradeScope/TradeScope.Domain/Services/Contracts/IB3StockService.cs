using TradeScope.Domain.Models.Dto;

namespace TradeScope.Domain.Services.Contracts
{
    public interface IB3StockService
    {
        Task<List<B3StockItemModel>> ListAllAsync(CancellationToken ct = default);
        Task<(List<B3StockItemModel> items, int totalItems)> ListPagedAsync(string? search, int pageNumber = 1, int pagesize = 100, CancellationToken ct = default);
        Task<B3StockItemModel?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<int> CreateAsync(B3StockItemModel dto, CancellationToken ct = default);
        Task<bool> UpdateAsync(B3StockItemModel dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
