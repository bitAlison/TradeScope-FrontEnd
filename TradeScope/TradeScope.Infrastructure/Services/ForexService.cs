using Microsoft.Data.SqlClient;
using TradeScope.Domain.Extensions;
using TradeScope.Domain.Models.Dto;
using TradeScope.Domain.Services.Contracts;
using TradeScope.Infrastructure.Repositories;

namespace TradeScope.Infrastructure.Services
{
    public sealed class ForexService : IForexService
    {
        private readonly ForexRepository forexRepository;

        public ForexService(ForexRepository forexRepository)
        {
            this.forexRepository = forexRepository;
        }

        public async Task<List<ForexItemModel>> ListAllAsync(CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            try
            {
                return [.. (await forexRepository.ListAllAsync(ct).ConfigureAwait(false)).Select(e => e.ToModel())];
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

        public async Task<(List<ForexItemModel> items, int totalItems)> ListPagedAsync(string? search, int pageNumber = 1, int pagesize = 100, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            try
            {
                var (entities, totalItems) = await forexRepository.ListPagedAsync(search, pageNumber, pagesize, ct).ConfigureAwait(false);
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

        public async Task<int> CreateAsync(ForexItemModel dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            try
            {
                return await forexRepository.CreateAsync(dto.ToEntity(), ct);
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
                return await forexRepository.DeleteAsync(id, ct);
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

        public async Task<ForexItemModel?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            try
            {
                return await forexRepository.GetByIdAsync(id, ct).ConfigureAwait(false) is { } entity
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

        public async Task<bool> UpdateAsync(ForexItemModel dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            try
            {
                return await forexRepository.UpdateAsync(dto.ToEntity(), ct);
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
