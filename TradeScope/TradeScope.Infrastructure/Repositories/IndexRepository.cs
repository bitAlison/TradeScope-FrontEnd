using Microsoft.EntityFrameworkCore;

using TradeScope.Domain.Models.Entities;

namespace TradeScope.Infrastructure.Repositories
{
    public sealed class IndexRepository : BaseRepository
    {
        public IndexRepository(TradeScopeDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<IndexEntity>> ListAllAsync(CancellationToken ct = default)
        {
            return await DbContext.Index
                .AsNoTracking()
                .OrderBy(a => a.Name)
                .ToListAsync(ct)
                .ConfigureAwait(false);
        }
        public async Task<(List<IndexEntity> items, int totalItems)> ListPagedAsync(
            string? search, int pageNumber = 1, int pagesize = 100, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (pageNumber < 1) pageNumber = 1;
            if (pagesize < 1) pagesize = 100;

            var query = DbContext.Index
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

        public async Task<IndexEntity?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await DbContext.Index
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(a => new IndexEntity
                {
                    Id = a.Id,
                    Stock = a.Stock,
                    Name = a.Name
                })
                .FirstOrDefaultAsync(ct);
        }

        public async Task<int> CreateAsync(IndexEntity entity, CancellationToken ct = default)
        {
            DbContext.Index.Add(entity);
            return await SaveChangesAsync(ct).ConfigureAwait(false);
        }

        public async Task<bool> UpdateAsync(IndexEntity dto, CancellationToken ct = default)
        {
            var entity = await DbContext.Index.FirstOrDefaultAsync(a => a.Id == dto.Id, ct);
            if (entity == null)
                return default;

            entity.Stock = dto.Stock;
            entity.Name = dto.Name.Trim();

            DbContext.Index.Update(entity);
            return await SaveChangesAsync(ct).ConfigureAwait(false) > 0;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await DbContext.Index.FirstOrDefaultAsync(a => a.Id == id, ct);
            if (entity == null)
                return false;

            DbContext.Index.Remove(entity);
            await SaveChangesAsync(ct).ConfigureAwait(false);
            return true;
        }
    }
}
