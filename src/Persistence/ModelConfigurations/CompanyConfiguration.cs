using Domain.Common.IdentityUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfigurations;

internal class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.Property(company => company.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(company => company.Description)
            .HasMaxLength(500)
            .IsRequired();

        builder.HasIndex(company => company.Name)
          .IsUnique();

        builder.HasMany(company => company.Employers)
            .WithOne(employer => employer.Company)
            .HasForeignKey(employer => employer.CompanyId)
            .HasConstraintName("FK_Company_Employer")
            .OnDelete(DeleteBehavior.NoAction);
    }
}