using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfigurations;

internal class ApplicantSkillConfiguration : IEntityTypeConfiguration<ApplicantSkill>
{
    public void Configure(EntityTypeBuilder<ApplicantSkill> builder)
    {
        builder.HasKey(e => new { e.ApplicantId, e.SkillId });

        builder.HasOne(e => e.Applicant)
            .WithMany(e => e.JobsSkill)
            .HasForeignKey(e => e.ApplicantId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Skill)
            .WithMany(e => e.Applicants)
            .HasForeignKey(e => e.SkillId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}