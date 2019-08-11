using Bolao.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bolao.Infra.Persistence.EF.Map
{
    public sealed class MapLotteryNumberResult : IEntityTypeConfiguration<LotteryNumberResult>
    {
        public void Configure(EntityTypeBuilder<LotteryNumberResult> builder)
        {
            // Table's name
            builder.ToTable("LotteryNumberResult");

            // PK
            builder.HasKey(x => x.LotteryNumberResultId);
            builder.Property(x => x.Number).HasMaxLength(2).IsRequired();
        }
    }
}