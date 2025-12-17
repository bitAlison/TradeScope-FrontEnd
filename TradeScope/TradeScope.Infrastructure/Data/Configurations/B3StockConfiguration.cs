using Microsoft.EntityFrameworkCore;

using TradeScope.Domain.Models.Entities;

namespace TradeScope.Infrastructure.Data.Configurations
{
    public sealed class B3StockConfiguration : BaseConfiguration, IEntityTypeConfiguration<B3StockEntity>
    {
        private const string AssetTableName = "tbl_b3_stocks";

        private const string Id = "id";
        private const string Stock = "stock";
        private const string Name = "name";
        private const string Logo = "logo";
        private const string Sector = "sector";
        private const string Type = "type";

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<B3StockEntity> builder)
        {
            //builder.ToTable(AssetTableName, DatabaseSchema);
            builder.ToTable(AssetTableName);

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName(Id);

            builder.Property(e => e.Stock)
                .HasColumnName(Stock)
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName(Name)
                .IsRequired();

            builder.Property(e => e.Logo)
                .HasColumnName(Logo)
                .IsRequired();

            builder.Property(e => e.Sector)
                .HasColumnName(Sector)
                .IsRequired();

            builder.Property(e => e.Type)
                .HasColumnName(Type)
                .IsRequired();

            builder.HasIndex(x => x.Stock)
                .HasDatabaseName($"IX_{AssetTableName}_{Stock}");

            builder.HasIndex(x => x.Name)
                .HasDatabaseName($"IX_{AssetTableName}_{Name}");

            builder.HasIndex(x => x.Sector)
                .HasDatabaseName($"IX_{AssetTableName}_{Sector}");

            builder.HasIndex(x => x.Type)
                .HasDatabaseName($"IX_{AssetTableName}_{Type}");
        }
    }
}
