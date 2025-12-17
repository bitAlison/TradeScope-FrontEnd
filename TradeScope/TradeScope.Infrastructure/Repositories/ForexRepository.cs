using Microsoft.EntityFrameworkCore;

using TradeScope.Domain.Models.Entities;

namespace TradeScope.Infrastructure.Repositories
{
    public sealed class ForexRepository : BaseRepository
    {
        public ForexRepository(TradeScopeDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<ForexEntity>> ListAllAsync(CancellationToken ct = default)
        {
            return await DbContext.Forex
                .AsNoTracking()
                .OrderBy(a => a.Currency)
                .ToListAsync(ct)
                .ConfigureAwait(false);
        }
        public async Task<(List<ForexEntity> items, int totalItems)> ListPagedAsync(
            string? search, int pageNumber = 1, int pagesize = 100, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (pageNumber < 1) pageNumber = 1;
            if (pagesize < 1) pagesize = 100;

            var query = DbContext.Forex
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                var term = search.Trim().ToUpper();
                query = query.Where(a => a.Currency.Contains(term, StringComparison.CurrentCultureIgnoreCase) ||
                a.Pair.Contains(term, StringComparison.CurrentCultureIgnoreCase));
            }

            return await ToPagedListAutoAsync(query, pageNumber, pagesize, cancellationToken).ConfigureAwait(false);
        }

        public async Task<ForexEntity?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await DbContext.Forex
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(a => new ForexEntity
                {
                    Id = a.Id,
                    Currency = a.Currency,
                    Pair = a.Pair
                })
                .FirstOrDefaultAsync(ct);
        }

        public async Task<int> CreateAsync(ForexEntity entity, CancellationToken ct = default)
        {
            DbContext.Forex.Add(entity);
            return await SaveChangesAsync(ct).ConfigureAwait(false);
        }

        public async Task<bool> UpdateAsync(ForexEntity dto, CancellationToken ct = default)
        {
            var entity = await DbContext.Forex.FirstOrDefaultAsync(a => a.Id == dto.Id, ct);
            if (entity == null)
                return default;

            entity.Currency = dto.Currency;
            entity.Pair = dto.Pair;

            DbContext.Forex.Update(entity);
            return await SaveChangesAsync(ct).ConfigureAwait(false) > 0;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await DbContext.Forex.FirstOrDefaultAsync(a => a.Id == id, ct);
            if (entity == null)
                return false;

            DbContext.Forex.Remove(entity);
            await SaveChangesAsync(ct).ConfigureAwait(false);
            return true;
        }
    }
}
