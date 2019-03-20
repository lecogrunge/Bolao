using Bolao.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bolao.Infra.Persistence.EF.Map
{
    public sealed class MapMegaSenaLottery : IEntityTypeConfiguration<MegaSenaLottery>
    {
        public void Configure(EntityTypeBuilder<MegaSenaLottery> builder)
        {
            //Nome da Tabela
            builder.ToTable("MegaSenaLottery");

            //Chave primaria
            builder.HasKey(x => x.IdMegaSenaLoterry);
        }
    }
}