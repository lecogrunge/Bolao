using Bolao.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bolao.Infra.Persistence.EF.Map
{
    public sealed class MapMegaSenaBetNumber : IEntityTypeConfiguration<MegaSenaBetNumber>
    {
        public void Configure(EntityTypeBuilder<MegaSenaBetNumber> builder)
        {
            //Nome da Tabela
            builder.ToTable("MegaSenaBetNumber");

            //Chave primaria
            builder.HasKey(x => x.IdMegaSenaBetNumber);
        }
    }
}