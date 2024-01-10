using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfigurations;

internal class ApplicantJobConfiguration : IEntityTypeConfiguration<Domain.Models.ApplicantJob>
{
    public void Configure(EntityTypeBuilder<Domain.Models.ApplicantJob> builder)
    {
        builder.HasKey(e => new { e.ApplicantId, e.JobId });

        builder.HasOne(e => e.Applicant)
            .WithMany(e => e.Jobs)
            .HasForeignKey(e => e.ApplicantId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.Job)
            .WithMany(e => e.Applicants)
            .HasForeignKey(e => e.JobId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
