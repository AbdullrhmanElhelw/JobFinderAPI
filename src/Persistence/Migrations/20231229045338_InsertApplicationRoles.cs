using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations;

/// <inheritdoc />
public partial class InsertApplicationRoles : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"
                INSERT INTO [dbo].[AspNetRoles] ([Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'Admin', N'ADMIN', NEWID())
                INSERT INTO [dbo].[AspNetRoles] ([Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'Company', N'COMPANY', NEWID())
                INSERT INTO [dbo].[AspNetRoles] ([Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'Applicant', N'APPLICANT', NEWID())
                INSERT INTO [dbo].[AspNetRoles] ([Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'Employer', N'EMPLOYER', NEWID())
            ");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"
                DELETE FROM [dbo].[AspNetRoles] WHERE [Name] = N'Admin'
                DELETE FROM [dbo].[AspNetRoles] WHERE [Name] = N'Company'
                DELETE FROM [dbo].[AspNetRoles] WHERE [Name] = N'Applicant'
                DELETE FROM [dbo].[AspNetRoles] WHERE [Name] = N'Employer'
            ");
    }
}
