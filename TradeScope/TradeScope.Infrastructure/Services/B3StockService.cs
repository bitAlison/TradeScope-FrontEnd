using Microsoft.Data.SqlClient;
using TradeScope.Domain.Extensions;
using TradeScope.Domain.Models.Dto;
using TradeScope.Domain.Services.Contracts;
using TradeScope.Infrastructure.Repositories;

namespace TradeScope.Infrastructure.Services
{
    public sealed class B3StockService : IB3StockService
    {
        private readonly B3StockRepository b3StockRepository;

        public B3StockService(B3StockRepository b3StockRepository)
        {
            this.b3StockRepository = b3StockRepository;
        }

        public async Task<List<B3StockItemModel>> ListAllAsync(CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            try
            {
                return [.. (await b3StockRepository.ListAllAsync(ct).ConfigureAwait(false)).Select(e => e.ToModel())];
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

        public async Task<(List<B3StockItemModel> items, int totalItems)> ListPagedAsync(string? search, int pageNumber = 1, int pagesize = 100, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            try
            {
                var (entities, totalItems) = await b3StockRepository.ListPagedAsync(search, pageNumber, pagesize, ct).ConfigureAwait(false);
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

        public async Task<int> CreateAsync(B3StockItemModel dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            try
            {
                return await b3StockRepository.CreateAsync(dto.ToEntity(), ct);
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
                return await b3StockRepository.DeleteAsync(id, ct);
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

        public async Task<B3StockItemModel?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            try
            {
                return await b3StockRepository.GetByIdAsync(id, ct).ConfigureAwait(false) is { } entity
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

        public async Task<bool> UpdateAsync(B3StockItemModel dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            try
            {
                return await b3StockRepository.UpdateAsync(dto.ToEntity(), ct);
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
