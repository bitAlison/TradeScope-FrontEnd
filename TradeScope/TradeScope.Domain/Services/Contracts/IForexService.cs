using TradeScope.Domain.Models.Dto;

namespace TradeScope.Domain.Services.Contracts
{
    public interface IForexService
    {
        Task<List<ForexItemModel>> ListAllAsync(CancellationToken ct = default);
        Task<(List<ForexItemModel> items, int totalItems)> ListPagedAsync(string? search, int pageNumber = 1, int pagesize = 100, CancellationToken ct = default);
        Task<ForexItemModel?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<int> CreateAsync(ForexItemModel dto, CancellationToken ct = default);
        Task<bool> UpdateAsync(ForexItemModel dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
