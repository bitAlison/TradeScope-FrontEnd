using TradeScope.Domain.Models.Dto;

namespace TradeScope.Domain.Services.Contracts
{
    public interface IIndexService
    {
        Task<List<IndexItemModel>> ListAllAsync(CancellationToken ct = default);
        Task<(List<IndexItemModel> items, int totalItems)> ListPagedAsync(string? search, int pageNumber = 1, int pagesize = 100, CancellationToken ct = default);
        Task<IndexItemModel?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<int> CreateAsync(IndexItemModel dto, CancellationToken ct = default);
        Task<bool> UpdateAsync(IndexItemModel dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
