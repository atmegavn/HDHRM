using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HD.HRM.Migrations
{
    public partial class Add_Level_to_Job : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                schema: "Hrm",
                table: "JobPosition");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                schema: "Hrm",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                schema: "Hrm",
                table: "Job");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                schema: "Hrm",
                table: "JobPosition",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
