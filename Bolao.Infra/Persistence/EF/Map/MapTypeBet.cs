using Bolao.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bolao.Infra.Persistence.EF.Map
{
    public sealed class MapTypeBet : IEntityTypeConfiguration<TypeBet>
    {
        public void Configure(EntityTypeBuilder<TypeBet> builder)
        {
            //Nome da Tabela
            builder.ToTable("TypeBet");

            //Chave primaria
            builder.HasKey(x => x.IdTypeBet);
        }
    }
}