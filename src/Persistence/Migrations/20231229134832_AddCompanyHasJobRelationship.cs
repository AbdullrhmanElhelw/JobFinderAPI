using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations;

/// <inheritdoc />
public partial class AddCompanyHasJobRelationship : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "CompanyJob",
            columns: table => new
            {
                CompanyId = table.Column<int>(type: "int", nullable: false),
                JobId = table.Column<int>(type: "int", nullable: false),
                SetedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CompanyJob", x => new { x.JobId, x.CompanyId });
                table.ForeignKey(
                    name: "FK_Companies_CompanyJobs",
                    column: x => x.CompanyId,
                    principalTable: "Companies",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.NoAction);
                table.ForeignKey(
                    name: "FK_CompanyJobs_Jobs",
                    column: x => x.JobId,
                    principalTable: "Jobs",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.NoAction);
            });

        migrationBuilder.CreateIndex(
            name: "IX_CompanyJob_CompanyId",
            table: "CompanyJob",
            column: "CompanyId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "CompanyJob");
    }
}