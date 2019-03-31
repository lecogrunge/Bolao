using Bolao.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bolao.Infra.Persistence.EF.Map
{
    public sealed class MapMegaSenaBetNumber : IEntityTypeConfiguration<MegaSenaBetNumber>
    {
        public void Configure(EntityTypeBuilder<MegaSenaBetNumber> builder)
        {
            // Table's name
            builder.ToTable("MegaSenaBetNumber");

            // PK
            builder.HasKey(x => x.MegaSenaBetNumberId);
        }
    }
}