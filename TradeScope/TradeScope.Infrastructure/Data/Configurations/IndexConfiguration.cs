using Microsoft.EntityFrameworkCore;

using TradeScope.Domain.Models.Entities;

namespace TradeScope.Infrastructure.Data.Configurations
{
    public sealed class IndexConfiguration : BaseConfiguration, IEntityTypeConfiguration<IndexEntity>
    {
        private const string AssetTableName = "tbl_indexes";

        private const string Id = "id";
        private const string Stock = "stock";
        private const string Name = "name";

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IndexEntity> builder)
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

            builder.HasIndex(x => x.Name)
                .HasDatabaseName($"IX_{AssetTableName}_{Name}");

        }
    }
}
