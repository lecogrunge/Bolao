using Bolao.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bolao.Infra.Persistence.EF.Map
{
	public sealed class MapContactType : IEntityTypeConfiguration<ContactType>
	{
		public void Configure(EntityTypeBuilder<ContactType> builder)
		{
			// Table's name
			builder.ToTable("ContactType");

			// PK
			builder.HasKey(x => x.ContactTypeId);
			builder.Property(x => x.Description).HasMaxLength(50).IsRequired();
		}
	}
}