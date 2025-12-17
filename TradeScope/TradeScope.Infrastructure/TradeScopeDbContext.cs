using Microsoft.EntityFrameworkCore;

using TradeScope.Domain.Models.Entities;

namespace TradeScope.Infrastructure
{
    public class TradeScopeDbContext : DbContext
    {

        public TradeScopeDbContext() { }

        public TradeScopeDbContext(DbContextOptions<TradeScopeDbContext> options) : base(options) { }

        public DbSet<CryptoEntity> Crypto => Set<CryptoEntity>();

        public DbSet<IndexEntity> Index => Set<IndexEntity>();

        public DbSet<CommoditieEntity> Commoditie => Set<CommoditieEntity>();

        public DbSet<B3StockEntity> B3Stock => Set<B3StockEntity>();

        public DbSet<ForexEntity> Forex => Set<ForexEntity>();

        public DbSet<AssetEntity> Asset => Set<AssetEntity>();



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema(BaseConfiguration.DatabaseSchema);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TradeScopeDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
