using Bolao.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bolao.Infra.Persistence.EF.Map
{
    public sealed class MapWinnerJackpot : IEntityTypeConfiguration<WinnerJackpot>
    {
        public void Configure(EntityTypeBuilder<WinnerJackpot> builder)
        {
            // Table's name
            builder.ToTable("WinnerJackpot");

            // PK
            builder.HasKey(x => x.WinnerJackpotId);
        }
    }
}