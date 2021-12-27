using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIGPIP.Migrations
{
    public partial class DatabaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    studentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    studentNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    studentLastNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    studentEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    studentBio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    studentCareer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    studentSemester = table.Column<int>(type: "int", nullable: false),
                    studentCountry = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.studentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
