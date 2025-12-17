using TradeScope.Infrastructure.Repositories;

namespace TradeScope.Infrastructure.Services
{
    public sealed class AssetService
    {
        private readonly AssetRepository assetRepository;

        public AssetService(AssetRepository assetRepository)
        {
            this.assetRepository = assetRepository;
        }

        public async Task<(List<T> items, int totalItems)> ListPagedAsync<T>(string? search, int pageNumber = 1, int pagesize = 100, CancellationToken cancellationToken = default)
        {
            var (items, totalItems) = await assetRepository.ListPagedAsync(search, pageNumber, pagesize, true, cancellationToken).ConfigureAwait(false);
            return (items.Cast<T>().ToList(), totalItems);
        }

        //public async Task<(List<AssetItemModel> items, int totalItems)> ListPagedAsync(
        //    string? search, int pageNumber = 1, int pagesize = 100,
        //    bool orderDesc = true, CancellationToken cancellationToken = default)
        //{
        //    cancellationToken.ThrowIfCancellationRequested();
        //    try
        //    {
        //        var (entities, totalItems) = await assetRepository.ListPagedAsync(
        //            search, pageNumber, pagesize, orderDesc, cancellationToken).ConfigureAwait(false);

        //        var items = entities
        //                .Select(e => e.ToModel())
        //                .ToList();
        //        return (items, totalItems);

        //    }
        //    catch (SqlException)
        //    {
        //        throw;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
    }
}
