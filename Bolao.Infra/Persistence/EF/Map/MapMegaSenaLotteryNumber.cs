using Bolao.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bolao.Infra.Persistence.EF.Map
{
    public sealed class MapMegaSenaLotteryNumber : IEntityTypeConfiguration<MegaSenaLotteryNumber>
    {
        public void Configure(EntityTypeBuilder<MegaSenaLotteryNumber> builder)
        {
            // Table's name
            builder.ToTable("MegaSenaLotteryNumber");

            // PK
            builder.HasKey(x => x.MegaSenaLoterryNumberId);
        }
    }
}