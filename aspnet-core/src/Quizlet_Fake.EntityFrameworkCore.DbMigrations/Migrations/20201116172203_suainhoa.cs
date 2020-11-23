using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizlet_Fake.Migrations
{
    public partial class suainhoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VN",
                table: "AppWords",
                newName: "Vn");

            migrationBuilder.RenameColumn(
                name: "EN",
                table: "AppWords",
                newName: "En");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vn",
                table: "AppWords",
                newName: "VN");

            migrationBuilder.RenameColumn(
                name: "En",
                table: "AppWords",
                newName: "EN");
        }
    }
}
