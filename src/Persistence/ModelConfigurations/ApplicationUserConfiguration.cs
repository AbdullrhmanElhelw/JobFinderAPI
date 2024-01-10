using Domain.Common.IdentityUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfigurations;

internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(e => e.Address)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.City)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Country)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.ZipCode)
            .HasMaxLength(10)
            .IsRequired();
    }
}