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
            // Table's name
            builder.ToTable("User");

            // PK
            builder.HasKey(x => x.UserId);
			builder.Property(x => x.FisrtName).HasMaxLength(15).IsRequired();
			builder.Property(x => x.LastName).HasMaxLength(30).IsRequired();
			builder.Property(x => x.Password).HasMaxLength(50).IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnType("DateTime").IsRequired();
            //builder.HasOne(s => s.UserSecurity);
            //builder.Property(x => x.UserSecurityId).IsRequired();

            // Mapping Object Value
            builder.OwnsOne<Email>(x => x.Email, cb =>
            {
                cb.Property(x => x.EmailAddress).HasColumnName("Email").HasMaxLength(80).IsRequired();
            });
        }
    }
}