using Bolao.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bolao.Infra.Persistence.EF.Map
{
	public sealed class MapUserSecurity : IEntityTypeConfiguration<UserSecurity>
	{
		public void Configure(EntityTypeBuilder<UserSecurity> builder)
		{
			// Table's name
			builder.ToTable("UserSecurity");

            // PK

            builder.HasKey(x => x.UserSecurityId);
            builder.HasOne(s => s.User);
			builder.Property(x => x.TokenCreateConfirmed).IsRequired();
		}
	}
}