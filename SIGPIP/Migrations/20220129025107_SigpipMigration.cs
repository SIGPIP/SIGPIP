using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIGPIP.Migrations
{
    public partial class SigpipMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    categoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    categoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    subCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    experienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    experienceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    experienceEntity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    experiencePlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    experienceDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    experienceStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    experienceEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.experienceId);
                });

            migrationBuilder.CreateTable(
                name: "Hability",
                columns: table => new
                {
                    habilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    habilityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hability", x => x.habilityId);
                });

            migrationBuilder.CreateTable(
                name: "Interest",
                columns: table => new
                {
                    interestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    interestName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interest", x => x.interestId);
                });

            migrationBuilder.CreateTable(
                name: "PendingProject",
                columns: table => new
                {
                    pendingProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pendingProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pendingProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PendingProject", x => x.pendingProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    projectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    studentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    projectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    projectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    projectRepoLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    projectZipData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    projectFramework = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectLanguages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectUploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    projectLastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.projectId);
                });

            migrationBuilder.CreateTable(
                name: "Reference",
                columns: table => new
                {
                    referenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    studentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    referenceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    referenceAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    referencePhone = table.Column<long>(type: "bigint", nullable: false),
                    referenceCompany = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reference", x => x.referenceId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    studentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    studentNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentLastNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentBio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    studentCareer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentSemester = table.Column<int>(type: "int", nullable: false),
                    studentCountry = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.studentId);
                });

            migrationBuilder.CreateTable(
                name: "Study",
                columns: table => new
                {
                    studyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    studentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    studyYear = table.Column<int>(type: "int", nullable: false),
                    studyGrade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studyPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studyCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    studyCountry = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Study", x => x.studyId);
                });

            migrationBuilder.CreateTable(
                name: "University",
                columns: table => new
                {
                    universityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    universityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    universityCountry = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University", x => x.universityId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropTable(
                name: "Hability");

            migrationBuilder.DropTable(
                name: "Interest");

            migrationBuilder.DropTable(
                name: "PendingProject");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Reference");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Study");

            migrationBuilder.DropTable(
                name: "University");
        }
    }
}
