using Bolao.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bolao.Infra.Persistence.EF.Map
{
    public sealed class MapLotteryNumberBet : IEntityTypeConfiguration<LotteryNumberBet>
    {
        public void Configure(EntityTypeBuilder<LotteryNumberBet> builder)
        {
            // Table's name
            builder.ToTable("LotteryNumberBet");

            // PK
            builder.HasKey(x => x.LotteryNumberBetId);
        }
    }
}