using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace TradeScope.Infrastructure.Repositories
{
    public abstract class BaseRepository
    {
        protected TradeScopeDbContext DbContext { get; }

        protected BaseRepository(TradeScopeDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return DbContext.SaveChangesAsync(cancellationToken);
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

        protected static IQueryable<T> ApplyPagination<T>(IQueryable<T> query, int pageNumber, int pageSize)
        {
            if (query == null || pageNumber <= 0 || pageSize <= 0)
                throw new Exception("Invalid pagination parameters.");

            return query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }

        protected static async Task<(List<T> items, int totalItems)> ToPagedListAsync<T>(
            IQueryable<T> query,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default)
        {
            if (query == null || pageNumber <= 0 || pageSize <= 0)
                throw new Exception("Invalid pagination parameters.");

            var totalItems = await query.CountAsync(cancellationToken).ConfigureAwait(false);
            var items = await ApplyPagination(query, pageNumber, pageSize)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return (items, totalItems);
        }

        protected static bool IsEfQuery<T>(IQueryable<T> query)
        {
            return query.Provider is IAsyncQueryProvider;
        }

        protected static (List<T> items, int totalItems) ToPagedListInMemory<T>(
            IQueryable<T> query,
            int pageNumber,
            int pageSize)
        {
            if (query == null || pageNumber <= 0 || pageSize <= 0)
                throw new Exception("Invalid pagination parameters.");
         
            var totalItems = query.Count();
            var items = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            
            return (items, totalItems);
        }

        protected static async Task<(List<T> items, int totalItems)> ToPagedListAutoAsync<T>(
            IQueryable<T> query,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default)
        {
            if (IsEfQuery(query))
            {
                return await ToPagedListAsync(query, pageNumber, pageSize, cancellationToken).ConfigureAwait(false);
            }

            return ToPagedListInMemory(query, pageNumber, pageSize);

        }
    }
}
