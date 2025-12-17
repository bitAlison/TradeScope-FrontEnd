using Microsoft.EntityFrameworkCore;

using TradeScope.Domain.Models.Entities;

namespace TradeScope.Infrastructure.Repositories
{
    public sealed class CryptoRepository : BaseRepository
    {
        public CryptoRepository(TradeScopeDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<CryptoEntity>> ListAllAsync(CancellationToken ct = default)
        {
            return await DbContext.Crypto
                .AsNoTracking()
                .OrderBy(a => a.Name)
                .ToListAsync(ct)
                .ConfigureAwait(false);
        }

        public async Task<(List<CryptoEntity> items, int totalItems)> ListPagedAsync(
            string? search, int pageNumber = 1, int pagesize = 100, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (pageNumber < 1) pageNumber = 1;
            if (pagesize < 1) pagesize = 100;

            var query = DbContext.Crypto
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

        public async Task<CryptoEntity?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await DbContext.Crypto
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(a => new CryptoEntity
                {
                    Id = a.Id,
                    Symbol = a.Symbol,
                    Name = a.Name
                })
                .FirstOrDefaultAsync(ct);
        }

        public async Task<int> CreateAsync(CryptoEntity entity, CancellationToken ct = default)
        {
            DbContext.Crypto.Add(entity);
            return await SaveChangesAsync(ct).ConfigureAwait(false);
        }

        public async Task<bool> UpdateAsync(CryptoEntity dto, CancellationToken ct = default)
        {
            var entity = await DbContext.Crypto.FirstOrDefaultAsync(a => a.Id == dto.Id, ct);
            if (entity == null)
                return default;

            entity.Symbol = dto.Symbol;
            entity.Name = dto.Name.Trim();

            DbContext.Crypto.Update(entity);
            return await SaveChangesAsync(ct).ConfigureAwait(false) > 0;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await DbContext.Crypto.FirstOrDefaultAsync(a => a.Id == id, ct);
            if (entity == null)
                return false;

            DbContext.Crypto.Remove(entity);
            await SaveChangesAsync(ct).ConfigureAwait(false);
            return true;
        }
    }
}
