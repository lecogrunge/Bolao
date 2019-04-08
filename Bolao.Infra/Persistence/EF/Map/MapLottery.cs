using Bolao.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bolao.Infra.Persistence.EF.Map
{
    public sealed class MapLottery : IEntityTypeConfiguration<Lottery>
    {
        public void Configure(EntityTypeBuilder<Lottery> builder)
        {
            // Table's name
            builder.ToTable("Lottery");

            // PK
            builder.HasKey(x => x.LoterryId);

            builder.Property(x => x.Price).HasColumnType<decimal>("decimal(5, 2)").IsRequired();
        }
    }
}