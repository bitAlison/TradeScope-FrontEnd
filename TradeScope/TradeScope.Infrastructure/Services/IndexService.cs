using Microsoft.Data.SqlClient;
using TradeScope.Domain.Extensions;
using TradeScope.Domain.Models.Dto;
using TradeScope.Domain.Services.Contracts;
using TradeScope.Infrastructure.Repositories;

namespace TradeScope.Infrastructure.Services
{
    public sealed class IndexService : IIndexService
    {
        private readonly IndexRepository indexRepository;

        public IndexService(IndexRepository indexRepository)
        {
            this.indexRepository = indexRepository;
        }
        public async Task<List<IndexItemModel>> ListAllAsync(CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            try
            {
                return [.. (await indexRepository.ListAllAsync(ct).ConfigureAwait(false)).Select(e => e.ToModel())];
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

        public async Task<(List<IndexItemModel> items, int totalItems)> ListPagedAsync(string? search, int pageNumber = 1, int pagesize = 100, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            try
            {
                var (entities, totalItems) = await indexRepository.ListPagedAsync(search, pageNumber, pagesize, ct).ConfigureAwait(false);
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

        public async Task<int> CreateAsync(IndexItemModel dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            try
            {
                return await indexRepository.CreateAsync(dto.ToEntity(), ct);
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
                return await indexRepository.DeleteAsync(id, ct);
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

        public async Task<IndexItemModel?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            try
            {
                return await indexRepository.GetByIdAsync(id, ct).ConfigureAwait(false) is { } entity
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

        public async Task<bool> UpdateAsync(IndexItemModel dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            try
            {
                return await indexRepository.UpdateAsync(dto.ToEntity(), ct);
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
