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
        }
    }
}