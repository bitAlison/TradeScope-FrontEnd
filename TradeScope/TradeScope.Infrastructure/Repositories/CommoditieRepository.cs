using Microsoft.EntityFrameworkCore;

using TradeScope.Domain.Models.Entities;

namespace TradeScope.Infrastructure.Repositories
{
    public sealed class CommoditieRepository : BaseRepository
    {
        public CommoditieRepository(TradeScopeDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<CommoditieEntity>> ListAllAsync(CancellationToken ct = default)
        {
            return await DbContext.Commoditie
                .AsNoTracking()
                .OrderBy(a => a.Name)
                .ToListAsync(ct)
                .ConfigureAwait(false);
        }

        public async Task<(List<CommoditieEntity> items, int totalItems)> ListPagedAsync(
            string? search, int pageNumber = 1, int pagesize = 100, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (pageNumber < 1) pageNumber = 1;
            if (pagesize < 1) pagesize = 100;

            var query = DbContext.Commoditie
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                var term = search.Trim().ToUpper();
                query = query.Where(a => a.Symbol.Contains(term, StringComparison.CurrentCultureIgnoreCase) ||
                a.Name.Contains(term, StringComparison.CurrentCultureIgnoreCase));
            }

            return await ToPagedListAutoAsync(query, pageNumber, pagesize, cancellationToken).ConfigureAwait(false);
        }

        public async Task<CommoditieEntity?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await DbContext.Commoditie
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(a => new CommoditieEntity
                {
                    Id = a.Id,
                    Symbol = a.Symbol,
                    Name = a.Name
                })
                .FirstOrDefaultAsync(ct);
        }

        public async Task<int> CreateAsync(CommoditieEntity entity, CancellationToken ct = default)
        {
            DbContext.Commoditie.Add(entity);
            return await SaveChangesAsync(ct).ConfigureAwait(false);
        }

        public async Task<bool> UpdateAsync(CommoditieEntity dto, CancellationToken ct = default)
        {
            var entity = await DbContext.Commoditie.FirstOrDefaultAsync(a => a.Id == dto.Id, ct);
            if (entity == null)
                return default;

            entity.Symbol = dto.Symbol;
            entity.Name = dto.Name.Trim();

            DbContext.Commoditie.Update(entity);
            return await SaveChangesAsync(ct).ConfigureAwait(false) > 0;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await DbContext.Commoditie.FirstOrDefaultAsync(a => a.Id == id, ct);
            if (entity == null)
                return false;

            DbContext.Commoditie.Remove(entity);
            await SaveChangesAsync(ct).ConfigureAwait(false);
            return true;
        }
    }
}
