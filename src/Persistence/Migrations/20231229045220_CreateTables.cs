using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations;

/// <inheritdoc />
public partial class CreateTables : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "AspNetRoles",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "AspNetUsers",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Skills",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                Level = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Skills", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "AspNetRoleClaims",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                RoleId = table.Column<int>(type: "int", nullable: false),
                ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                table.ForeignKey(
                    name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                    column: x => x.RoleId,
                    principalTable: "AspNetRoles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Applicants",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false),
                FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Applicants", x => x.Id);
                table.ForeignKey(
                    name: "FK_Applicants_AspNetUsers_Id",
                    column: x => x.Id,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "AspNetUserClaims",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                UserId = table.Column<int>(type: "int", nullable: false),
                ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                table.ForeignKey(
                    name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                    column: x => x.UserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "AspNetUserLogins",
            columns: table => new
            {
                LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                UserId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                table.ForeignKey(
                    name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                    column: x => x.UserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "AspNetUserRoles",
            columns: table => new
            {
                UserId = table.Column<int>(type: "int", nullable: false),
                RoleId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                table.ForeignKey(
                    name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                    column: x => x.RoleId,
                    principalTable: "AspNetRoles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                    column: x => x.UserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "AspNetUserTokens",
            columns: table => new
            {
                UserId = table.Column<int>(type: "int", nullable: false),
                LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                table.ForeignKey(
                    name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                    column: x => x.UserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Companies",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Companies", x => x.Id);
                table.ForeignKey(
                    name: "FK_Companies_AspNetUsers_Id",
                    column: x => x.Id,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "ApplicantSkill",
            columns: table => new
            {
                ApplicantId = table.Column<int>(type: "int", nullable: false),
                SkillId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ApplicantSkill", x => new { x.ApplicantId, x.SkillId });
                table.ForeignKey(
                    name: "FK_ApplicantSkill_Applicants_ApplicantId",
                    column: x => x.ApplicantId,
                    principalTable: "Applicants",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_ApplicantSkill_Skills_SkillId",
                    column: x => x.SkillId,
                    principalTable: "Skills",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Resume",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ApplicantId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Resume", x => x.Id);
                table.ForeignKey(
                    name: "FK_Applicant_Resume",
                    column: x => x.ApplicantId,
                    principalTable: "Applicants",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "Employers",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false),
                FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                CompanyId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Employers", x => x.Id);
                table.ForeignKey(
                    name: "FK_Company_Employer",
                    column: x => x.CompanyId,
                    principalTable: "Companies",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_Employers_AspNetUsers_Id",
                    column: x => x.Id,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Jobs",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                EmployerId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Jobs", x => x.Id);
                table.ForeignKey(
                    name: "FK_Employer_Job",
                    column: x => x.EmployerId,
                    principalTable: "Employers",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "ApplicantJob",
            columns: table => new
            {
                ApplicantId = table.Column<int>(type: "int", nullable: false),
                JobId = table.Column<int>(type: "int", nullable: false),
                AppliedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                isAccepted = table.Column<bool>(type: "bit", nullable: false),
                isReviewed = table.Column<bool>(type: "bit", nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ApplicantJob", x => new { x.ApplicantId, x.JobId });
                table.ForeignKey(
                    name: "FK_ApplicantJob_Applicants_ApplicantId",
                    column: x => x.ApplicantId,
                    principalTable: "Applicants",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_ApplicantJob_Jobs_JobId",
                    column: x => x.JobId,
                    principalTable: "Jobs",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "JobSkill",
            columns: table => new
            {
                JobId = table.Column<int>(type: "int", nullable: false),
                SkillId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_JobSkill", x => new { x.JobId, x.SkillId });
                table.ForeignKey(
                    name: "FK_JobSkill_Jobs_JobId",
                    column: x => x.JobId,
                    principalTable: "Jobs",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_JobSkill_Skills_SkillId",
                    column: x => x.SkillId,
                    principalTable: "Skills",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_ApplicantJob_JobId",
            table: "ApplicantJob",
            column: "JobId");

        migrationBuilder.CreateIndex(
            name: "IX_ApplicantSkill_SkillId",
            table: "ApplicantSkill",
            column: "SkillId");

        migrationBuilder.CreateIndex(
            name: "IX_AspNetRoleClaims_RoleId",
            table: "AspNetRoleClaims",
            column: "RoleId");

        migrationBuilder.CreateIndex(
            name: "RoleNameIndex",
            table: "AspNetRoles",
            column: "NormalizedName",
            unique: true,
            filter: "[NormalizedName] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_AspNetUserClaims_UserId",
            table: "AspNetUserClaims",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_AspNetUserLogins_UserId",
            table: "AspNetUserLogins",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_AspNetUserRoles_RoleId",
            table: "AspNetUserRoles",
            column: "RoleId");

        migrationBuilder.CreateIndex(
            name: "EmailIndex",
            table: "AspNetUsers",
            column: "NormalizedEmail");

        migrationBuilder.CreateIndex(
            name: "UserNameIndex",
            table: "AspNetUsers",
            column: "NormalizedUserName",
            unique: true,
            filter: "[NormalizedUserName] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_Companies_Name",
            table: "Companies",
            column: "Name",
            unique: true,
            filter: "[Name] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_Employers_CompanyId",
            table: "Employers",
            column: "CompanyId");

        migrationBuilder.CreateIndex(
            name: "IX_Jobs_EmployerId",
            table: "Jobs",
            column: "EmployerId");

        migrationBuilder.CreateIndex(
            name: "IX_JobSkill_SkillId",
            table: "JobSkill",
            column: "SkillId");

        migrationBuilder.CreateIndex(
            name: "IX_Resume_ApplicantId",
            table: "Resume",
            column: "ApplicantId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "ApplicantJob");

        migrationBuilder.DropTable(
            name: "ApplicantSkill");

        migrationBuilder.DropTable(
            name: "AspNetRoleClaims");

        migrationBuilder.DropTable(
            name: "AspNetUserClaims");

        migrationBuilder.DropTable(
            name: "AspNetUserLogins");

        migrationBuilder.DropTable(
            name: "AspNetUserRoles");

        migrationBuilder.DropTable(
            name: "AspNetUserTokens");

        migrationBuilder.DropTable(
            name: "JobSkill");

        migrationBuilder.DropTable(
            name: "Resume");

        migrationBuilder.DropTable(
            name: "AspNetRoles");

        migrationBuilder.DropTable(
            name: "Jobs");

        migrationBuilder.DropTable(
            name: "Skills");

        migrationBuilder.DropTable(
            name: "Applicants");

        migrationBuilder.DropTable(
            name: "Employers");

        migrationBuilder.DropTable(
            name: "Companies");

        migrationBuilder.DropTable(
            name: "AspNetUsers");
    }
}