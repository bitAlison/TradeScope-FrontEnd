using Microsoft.EntityFrameworkCore;

using TradeScope.Domain.Models.Entities;

namespace TradeScope.Infrastructure.Repositories
{
    public sealed class B3StockRepository : BaseRepository
    {
        public B3StockRepository(TradeScopeDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<B3StockEntity>> ListAllAsync(CancellationToken ct = default)
        {
            return await DbContext.B3Stock
                .AsNoTracking()
                .OrderBy(a => a.Stock)
                .ToListAsync(ct)
                .ConfigureAwait(false);
        }

        public async Task<(List<B3StockEntity> items, int totalItems)> ListPagedAsync(
            string? search, int pageNumber = 1, int pagesize = 100, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (pageNumber < 1) pageNumber = 1;
            if (pagesize < 1) pagesize = 100;

            var query = DbContext.B3Stock
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                var term = search.Trim().ToUpper();
                query = query.Where(a => a.Stock.Contains(term, StringComparison.CurrentCultureIgnoreCase) ||
                a.Name.Contains(term, StringComparison.CurrentCultureIgnoreCase));
            }

            return await ToPagedListAutoAsync(query, pageNumber, pagesize, cancellationToken).ConfigureAwait(false);
        }

        public async Task<B3StockEntity?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await DbContext.B3Stock
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(a => new B3StockEntity
                {
                    Id = a.Id,
                    Stock = a.Stock,
                    Name = a.Name,
                    Logo = a.Logo,
                    Sector = a.Sector,
                    Type = a.Type
                })
                .FirstOrDefaultAsync(ct);
        }

        public async Task<int> CreateAsync(B3StockEntity entity, CancellationToken ct = default)
        {
            DbContext.B3Stock.Add(entity);
            return await SaveChangesAsync(ct).ConfigureAwait(false);
        }

        public async Task<bool> UpdateAsync(B3StockEntity dto, CancellationToken ct = default)
        {
            var entity = await DbContext.B3Stock.FirstOrDefaultAsync(a => a.Id == dto.Id, ct);
            if (entity == null)
                return default;

            entity.Stock = dto.Stock;
            entity.Name = dto.Name.Trim();
            entity.Logo = dto.Logo;
            entity.Sector = dto.Sector;
            entity.Type = dto.Type;

            DbContext.B3Stock.Update(entity);
            return await SaveChangesAsync(ct).ConfigureAwait(false) > 0;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await DbContext.B3Stock.FirstOrDefaultAsync(a => a.Id == id, ct);
            if (entity == null)
                return false;

            DbContext.B3Stock.Remove(entity);
            await SaveChangesAsync(ct).ConfigureAwait(false);
            return true;
        }
    }
}
