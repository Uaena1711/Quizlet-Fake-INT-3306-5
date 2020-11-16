using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizlet_Fake.Migrations
{
    public partial class te : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<int>(
                name: "wordnumber",
                table: "AppLessons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "wordnumber",
                table: "AppCourses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "wordnumber",
                table: "AppLessons");

            migrationBuilder.DropColumn(
                name: "wordnumber",
                table: "AppCourses");

        }
    }
}
