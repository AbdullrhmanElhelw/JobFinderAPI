using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfigurations;

internal class JobSkillConfiguration : IEntityTypeConfiguration<JobSkill>
{
    public void Configure(EntityTypeBuilder<JobSkill> builder)
    {
        builder.HasKey(e => new { e.JobId, e.SkillId });

        builder.HasOne(e => e.Job)
            .WithMany(e => e.Skills)
            .HasForeignKey(e => e.JobId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.Skill)
            .WithMany(e => e.JobSkills)
            .HasForeignKey(e => e.SkillId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
