using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfigurations;

internal class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
{
    public void Configure(EntityTypeBuilder<Experience> builder)
    {
        builder.Property(e => e.Title)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Company)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.StartDate)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        builder.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("GETDATE()");

        builder.Property(e => e.IsCurrent)
            .HasDefaultValue(false);

        builder.Property(e => e.Location)
            .HasMaxLength(50)
            .IsRequired(false);

        builder.HasOne(e => e.Applicant)
            .WithMany(a => a.Experiences)
            .HasForeignKey(e => e.ApplicantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}