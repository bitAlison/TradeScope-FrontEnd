using Microsoft.EntityFrameworkCore;

using TradeScope.Domain.Models.Entities;

namespace TradeScope.Infrastructure.Data.Configurations
{
    public sealed class CryptoConfiguration : BaseConfiguration, IEntityTypeConfiguration<CryptoEntity>
    {
        private const string AssetTableName = "tbl_cryptos";

        private const string Id = "id";
        private const string Symbol = "symbol";
        private const string Name = "name";

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CryptoEntity> builder)
        {
            //builder.ToTable(AssetTableName, DatabaseSchema);
            builder.ToTable(AssetTableName);

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName(Id);

            builder.Property(e => e.Symbol)
                .HasColumnName(Symbol)
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName(Name)
                .IsRequired();

            builder.HasIndex(x => x.Name)
                .HasDatabaseName($"IX_{AssetTableName}_{Name}");

        }
    }
}
