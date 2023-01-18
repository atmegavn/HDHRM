using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HD.HRM.Migrations
{
    public partial class Employee_UserId_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "Hrm",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Hrm",
                table: "Employee");
        }
    }
}
