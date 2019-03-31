using Bolao.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bolao.Infra.Persistence.EF.Map
{
    public sealed class MapOwnerJackpot : IEntityTypeConfiguration<OwnerJackpot>
    {
        public void Configure(EntityTypeBuilder<OwnerJackpot> builder)
        {
            // Table's name
            builder.ToTable("OwnerJackpot");

            // PK
            builder.HasKey(x => x.OwnerJackpotId);
        }
    }
}