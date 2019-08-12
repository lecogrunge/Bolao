using Bolao.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bolao.Infra.Persistence.EF.Map
{
    public sealed class MapTypeBet : IEntityTypeConfiguration<TypeBet>
    {
        public void Configure(EntityTypeBuilder<TypeBet> builder)
        {
            // Table's name
            builder.ToTable("TypeBet");

            // PK
            builder.HasKey(x => x.TypeBetId);
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.CountNumberBet).IsRequired();
            builder.Property(x => x.CountNumberResult).IsRequired();
        }
    }
}