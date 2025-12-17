using Microsoft.EntityFrameworkCore;

using TradeScope.Domain.Models.Entities;

namespace TradeScope.Infrastructure.Data.Configurations
{
    public sealed class AssetConfiguration : BaseConfiguration, IEntityTypeConfiguration<AssetEntity>
    {
        private const string AssetTableName = "tbl_assets";

        private const string Id = "id";
        private const string Asset = "asset";
        private const string Type = "type";
        private const string Name = "name";
        private const string Source = "source";
        private const string Endpoint = "enpoint";

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AssetEntity> builder)
        {
            //builder.ToTable(AssetTableName, DatabaseSchema);
            builder.ToTable(AssetTableName);

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName(Id);

            builder.Property(e => e.Asset)
                .HasColumnName(Asset)
                .IsRequired();

            builder.Property(e => e.Type)
                .HasColumnName(Type)
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName(Name)
                .IsRequired();

            builder.Property(e => e.Source)
                .HasColumnName(Source)
                .IsRequired();

            builder.Property(e => e.Endpoint)
                .HasColumnName(Endpoint);

            //builder.Property(e => e.DateCreate)
            //    .HasColumnName(DateCreate)
            //    .HasColumnType("DATETIME2")
            //    .IsRequired();

            builder.HasIndex(x => x.Asset)
                .HasDatabaseName($"IX_{AssetTableName}_{Asset}");

            builder.HasIndex(x => x.Type)
                .HasDatabaseName($"IX_{AssetTableName}_{Type}");

            builder.HasIndex(x => x.Source)
                .HasDatabaseName($"IX_{AssetTableName}_{Source}");
        }
    }
}
