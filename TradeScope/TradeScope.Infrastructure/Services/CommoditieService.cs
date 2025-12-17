using Microsoft.Data.SqlClient;
using TradeScope.Domain.Extensions;
using TradeScope.Domain.Models.Dto;
using TradeScope.Domain.Services.Contracts;
using TradeScope.Infrastructure.Repositories;

namespace TradeScope.Infrastructure.Services
{
    public sealed class CommoditieService : ICommoditieService
    {
        private readonly CommoditieRepository commoditieRepository;

        public CommoditieService(CommoditieRepository commoditieRepository)
        {
            this.commoditieRepository = commoditieRepository;
        }

        public async Task<List<CommoditieItemModel>> ListAllAsync(CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            try
            {
                return [.. (await commoditieRepository.ListAllAsync(ct).ConfigureAwait(false)).Select(e => e.ToModel())];
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

        public async Task<(List<CommoditieItemModel> items, int totalItems)> ListPagedAsync(string? search, int pageNumber = 1, int pagesize = 100, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            try
            {
                var (entities, totalItems) = await commoditieRepository.ListPagedAsync(search, pageNumber, pagesize, ct).ConfigureAwait(false);
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

        public async Task<int> CreateAsync(CommoditieItemModel dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            try
            {
                return await commoditieRepository.CreateAsync(dto.ToEntity(), ct);
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
                return await commoditieRepository.DeleteAsync(id, ct);
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

        public async Task<CommoditieItemModel?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();
            try
            {
                return await commoditieRepository.GetByIdAsync(id, ct).ConfigureAwait(false) is { } entity
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

        public async Task<bool> UpdateAsync(CommoditieItemModel dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            try
            {
                return await commoditieRepository.UpdateAsync(dto.ToEntity(), ct);
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
