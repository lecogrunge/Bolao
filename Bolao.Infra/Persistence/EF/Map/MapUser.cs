using Bolao.Domain.Domains;
using Bolao.Domain.ObjectValue;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bolao.Infra.Persistence.EF.Map
{
    public sealed class MapUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Nome da Tabela
            builder.ToTable("User");

            //Chave primaria
            builder.HasKey(x => x.IdUser);

            builder.Property(x => x.Password).HasMaxLength(36).IsRequired();

            //Mapeando objetos de valor
            builder.OwnsOne<Email>(x => x.Email, cb =>
            {
                cb.Property(x => x.EmailAddress).HasColumnName("Email").HasMaxLength(80).IsRequired();
            });
        }
    }
}