using Microsoft.Data.SqlClient;

using TradeScope.Domain.Extensions;
using TradeScope.Domain.Models.Dto;
using TradeScope.Domain.Services.Contracts;
using TradeScope.Infrastructure.Repositories;

namespace TradeScope.Infrastructure.Services
{
    public sealed class CryptoService : ICryptoService
    {
        private readonly CryptoRepository cryptoRepository;

        public CryptoService(CryptoRepository cryptoRepository)
        {
            this.cryptoRepository = cryptoRepository;
        }

        public async Task<List<CryptoItemModel>> ListAllAsync(CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            try
            {
                return [.. (await cryptoRepository.ListAllAsync(ct).ConfigureAwait(false)).Select(e => e.ToModel())];
            }
            catch (SqlException)
            {
                throw;
            }
            catch
            {
                throw;
            }
        }

        public async Task<(List<CryptoItemModel> items, int totalItems)> ListPagedAsync(string? search, int pageNumber = 1, int pagesize = 100, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            try
            {
                var (entities, totalItems) = await cryptoRepository.ListPagedAsync(search, pageNumber, pagesize, ct).ConfigureAwait(false);
                var items = entities.Select(e => e.ToModel()).ToList();
                return (items, totalItems);
            }
            catch (SqlException)
            {
                throw;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> CreateAsync(CryptoItemModel dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            try
            {
                return await cryptoRepository.CreateAsync(dto.ToEntity(), ct);
            }
            catch (SqlException)
            {
                throw;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            try
            {
                return await cryptoRepository.DeleteAsync(id, ct);
            }
            catch (SqlException)
            {
                throw;
            }
            catch
            {
                throw;
            }
        }

        public async Task<CryptoItemModel?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            try {
                return await cryptoRepository.GetByIdAsync(id, ct).ConfigureAwait(false) is { } entity
                    ? entity.ToModel()
                    : default;
            }
            catch (SqlException)
            {
                throw;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(CryptoItemModel dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            try {
                 return await cryptoRepository.UpdateAsync(dto.ToEntity(), ct);
            }
            catch (SqlException)
            {
                throw;
            }
            catch
            {
                throw;
            }
        }
    }
}
