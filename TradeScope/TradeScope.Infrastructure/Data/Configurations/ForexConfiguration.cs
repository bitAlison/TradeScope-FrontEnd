using Microsoft.EntityFrameworkCore;

using TradeScope.Domain.Models.Entities;

namespace TradeScope.Infrastructure.Data.Configurations
{
    public sealed class ForexConfiguration : BaseConfiguration, IEntityTypeConfiguration<ForexEntity>
    {
        private const string AssetTableName = "tbl_forex";

        private const string Id = "id";
        private const string Currency = "currency";
        private const string Pair = "pair";

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ForexEntity> builder)
        {
            //builder.ToTable(AssetTableName, DatabaseSchema);
            builder.ToTable(AssetTableName);

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName(Id);

            builder.Property(e => e.Currency)
                .HasColumnName(Currency)
                .IsRequired();

            builder.Property(e => e.Pair)
                .HasColumnName(Pair)
                .IsRequired();
        }
    }
}
