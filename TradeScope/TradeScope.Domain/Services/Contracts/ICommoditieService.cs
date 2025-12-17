using TradeScope.Domain.Models.Dto;

namespace TradeScope.Domain.Services.Contracts
{
    public interface ICommoditieService
    {
        Task<List<CommoditieItemModel>> ListAllAsync(CancellationToken ct = default);
        Task<(List<CommoditieItemModel> items, int totalItems)> ListPagedAsync(string? search, int pageNumber = 1, int pagesize = 100, CancellationToken ct = default);
        Task<CommoditieItemModel?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<int> CreateAsync(CommoditieItemModel dto, CancellationToken ct = default);
        Task<bool> UpdateAsync(CommoditieItemModel dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
