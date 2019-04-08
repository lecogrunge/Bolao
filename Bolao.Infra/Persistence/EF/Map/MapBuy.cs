using Bolao.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bolao.Infra.Persistence.EF.Map
{
    public sealed class MapBuy : IEntityTypeConfiguration<Buy>
    {
        public void Configure(EntityTypeBuilder<Buy> builder)
        {
            // Table's name
            builder.ToTable("Buy");

            // PK
            builder.HasKey(x => x.BuyId);

            builder.Property(x => x.UnitPrice).HasColumnType<decimal>("decimal(5, 2)").IsRequired();
            builder.Property(x => x.Total).HasColumnType<decimal>("decimal(5, 2)").IsRequired();
        }
    }
}