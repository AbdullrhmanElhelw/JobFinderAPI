using Domain.Common.IdentityUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfigurations;

internal class AdminConfiguration : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.Property(admin => admin.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(admin => admin.LastName)
            .HasMaxLength(50)
            .IsRequired();
    }
}