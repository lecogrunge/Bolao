using Bolao.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bolao.Infra.Persistence.EF.Map
{
    public sealed class MapUserContactType : IEntityTypeConfiguration<UserContactType>
    {
        public void Configure(EntityTypeBuilder<UserContactType> builder)
        {
            // Table's name
            builder.ToTable("UserContactType");

            // PK
            builder.HasKey(x => new { x.UserContactTypeId});

            builder.HasOne(x => x.User)
                   .WithMany(x => x.UsersContactTypes)
                   .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.ContactType)
                   .WithMany(x => x.UsersContactTypes)
                   .HasForeignKey(x => x.ContactTypeId);
        }
    }
}