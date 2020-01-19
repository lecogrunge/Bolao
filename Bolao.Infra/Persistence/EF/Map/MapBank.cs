using Bolao.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bolao.Infra.Persistence.EF.Map
{
    public sealed class MapBank : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            // Table's name
            builder.ToTable("Bank");

            // PK
            builder.HasKey(x => x.BankId);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        }
    }
}