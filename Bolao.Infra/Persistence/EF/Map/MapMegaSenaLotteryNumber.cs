using Bolao.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bolao.Infra.Persistence.EF.Map
{
    public sealed class MapMegaSenaLotteryNumber : IEntityTypeConfiguration<MegaSenaLotteryNumber>
    {
        public void Configure(EntityTypeBuilder<MegaSenaLotteryNumber> builder)
        {
            //Nome da Tabela
            builder.ToTable("MegaSenaLotteryNumber");

            //Chave primaria
            builder.HasKey(x => x.IdMegaSenaLoterryNumber);
        }
    }
}