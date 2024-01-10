using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfigurations;

internal class CompanyJobConfiguration : IEntityTypeConfiguration<CompanyJob>
{
    public void Configure(EntityTypeBuilder<CompanyJob> builder)
    {
        builder.HasKey(e => new { e.JobId, e.CompanyId });

        builder.HasOne(e => e.Company)
               .WithMany(e => e.CompanyJobs)
               .HasForeignKey(e => e.CompanyId)
               .HasConstraintName("FK_Companies_CompanyJobs");

        builder.HasOne(e => e.Job)
               .WithMany(e => e.CompanyJobs)
               .HasForeignKey(e => e.JobId)
               .HasConstraintName("FK_CompanyJobs_Jobs");


    }
}
