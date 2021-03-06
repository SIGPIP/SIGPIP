using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIGPIP.Migrations
{
    public partial class DatabaseMigrationTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "studentNames",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "studentLastNames",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "studentEmail",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "studentCountry",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "studentCareer",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                    table.PrimaryKey("PK_Experience", x => x.studentId);
                });

            migrationBuilder.CreateTable(
                name: "Hability",
                columns: table => new
                {
                    habilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    habilityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    projectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    projectRepoLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    projectImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    projectZipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    projectFramework = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.projectId);
                });

            migrationBuilder.CreateTable(
                name: "Reference",
                columns: table => new
                {
                    studentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    referenceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    referenceAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    referencePhone = table.Column<int>(type: "int", nullable: false),
                    referenceCompany = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reference", x => x.studentId);
                });

            migrationBuilder.CreateTable(
                name: "Study",
                columns: table => new
                {
                    studyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "Study");

            migrationBuilder.DropTable(
                name: "University");

            migrationBuilder.AlterColumn<string>(
                name: "studentNames",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "studentLastNames",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "studentEmail",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "studentCountry",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "studentCareer",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
