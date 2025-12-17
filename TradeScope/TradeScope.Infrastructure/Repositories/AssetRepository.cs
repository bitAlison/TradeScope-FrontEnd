using Microsoft.EntityFrameworkCore;

using TradeScope.Domain.Models.Entities;

namespace TradeScope.Infrastructure.Repositories
{
    public sealed class AssetRepository : BaseRepository
    {
        public AssetRepository(TradeScopeDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<(List<AssetEntity> items, int totalItems)> ListPagedAsync(
            string? search, int pageNumber = 1, int pagesize = 100, bool orderDesc = true, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (pageNumber < 1) pageNumber = 1;
            if (pagesize < 1) pagesize = 100;

            var query = DbContext.Asset
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                var term = search.Trim().ToUpper();
                query = query.Where(a => a.Asset.Contains(term, StringComparison.CurrentCultureIgnoreCase) ||
                a.Name.Contains(term, StringComparison.CurrentCultureIgnoreCase));
            }

            query = orderDesc
                ? query.OrderByDescending(a => a.Asset)
                    .ThenBy(a => a.Name)
                : query.OrderBy(a => a.Asset)
                    .ThenBy(a => a.Name);

            return await ToPagedListAutoAsync(query, pageNumber, pagesize, cancellationToken).ConfigureAwait(false);

        }

        public async Task<AssetEntity?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await DbContext.Asset
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(a => new AssetEntity
                {
                    Id = a.Id,
                    Asset = a.Asset,
                    Type = a.Type,
                    Name = a.Name,
                    Source = a.Source,
                    Endpoint = a.Endpoint,
                    //DateCreate = a.DateCreate
                })
                .FirstOrDefaultAsync(ct);
        }

        public async Task<AssetEntity> CreateAsync(AssetEntity entity, CancellationToken ct = default)
        {
            DbContext.Asset.Add(entity);
            await SaveChangesAsync(ct).ConfigureAwait(false);
            return entity;
        }

        public async Task<AssetEntity?> UpdateAsync(AssetEntity dto, CancellationToken ct = default)
        {
            var entity = await DbContext.Asset.FirstOrDefaultAsync(a => a.Id == dto.Id, ct);
            if (entity == null)
                return null;

            entity.Asset = dto.Asset;
            entity.Type = dto.Type;
            entity.Name = dto.Name.Trim();
            entity.Source = dto.Source;
            entity.Endpoint = dto.Endpoint;

            DbContext.Asset.Update(entity);
            await SaveChangesAsync(ct).ConfigureAwait(false);
            return entity;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await DbContext.Asset.FirstOrDefaultAsync(a => a.Id == id, ct);
            if (entity == null)
                return false;

            DbContext.Asset.Remove(entity);
            await SaveChangesAsync(ct).ConfigureAwait(false);
            return true;
        }
    }
}
