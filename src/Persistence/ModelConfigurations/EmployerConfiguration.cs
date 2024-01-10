using Domain.Common.IdentityUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfigurations;

internal class EmployerConfiguration : IEntityTypeConfiguration<Employer>
{
    public void Configure(EntityTypeBuilder<Employer> builder)
    {
        builder.Property(e => e.FirstName)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(e => e.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasMany(e => e.Jobs)
            .WithOne(j => j.Employer)
            .HasForeignKey(j => j.EmployerId)
            .HasConstraintName("FK_Employer_Job")
            .OnDelete(DeleteBehavior.NoAction);
    }
}