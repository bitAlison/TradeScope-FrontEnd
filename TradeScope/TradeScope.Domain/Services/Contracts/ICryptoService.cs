using TradeScope.Domain.Models.Dto;

namespace TradeScope.Domain.Services.Contracts
{
    public interface ICryptoService
    {
        Task<List<CryptoItemModel>> ListAllAsync(CancellationToken ct = default);
        Task<(List<CryptoItemModel> items, int totalItems)> ListPagedAsync(string? search, int pageNumber = 1, int pagesize = 100, CancellationToken ct = default);
        Task<CryptoItemModel?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<int> CreateAsync(CryptoItemModel dto, CancellationToken ct = default);
        Task<bool> UpdateAsync(CryptoItemModel dto, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
