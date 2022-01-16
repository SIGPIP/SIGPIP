using Microsoft.EntityFrameworkCore.Migrations;

namespace SIGPIP.Migrations
{
    public partial class experienceUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Experience",
                table: "Experience");

            migrationBuilder.AddColumn<int>(
                name: "experienceId",
                table: "Experience",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Experience",
                table: "Experience",
                column: "experienceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Experience",
                table: "Experience");

            migrationBuilder.DropColumn(
                name: "experienceId",
                table: "Experience");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Experience",
                table: "Experience",
                column: "studentId");
        }
    }
}
