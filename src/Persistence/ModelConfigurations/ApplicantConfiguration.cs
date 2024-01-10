using Domain.Common.IdentityUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfigurations;

public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
{
    public void Configure(EntityTypeBuilder<Applicant> builder)
    {
        builder.Property(a => a.FirstName)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(a => a.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasMany(a => a.Resumes)
             .WithOne(r => r.Applicant)
             .HasForeignKey(r => r.ApplicantId)
             .HasConstraintName("FK_Applicant_Resume")
             .OnDelete(DeleteBehavior.NoAction);
    }
}