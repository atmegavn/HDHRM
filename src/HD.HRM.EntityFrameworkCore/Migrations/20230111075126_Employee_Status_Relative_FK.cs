using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HD.HRM.Migrations
{
    public partial class Employee_Status_Relative_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                schema: "Hrm",
                table: "Relative",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                schema: "Hrm",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relative_EmployeeId",
                schema: "Hrm",
                table: "Relative",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_StatusId",
                schema: "Hrm",
                table: "Employee",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Status_StatusId",
                schema: "Hrm",
                table: "Employee",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Relative_Employee_EmployeeId",
                schema: "Hrm",
                table: "Relative",
                column: "EmployeeId",
                principalSchema: "Hrm",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Status_StatusId",
                schema: "Hrm",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Relative_Employee_EmployeeId",
                schema: "Hrm",
                table: "Relative");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Relative_EmployeeId",
                schema: "Hrm",
                table: "Relative");

            migrationBuilder.DropIndex(
                name: "IX_Employee_StatusId",
                schema: "Hrm",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "StatusId",
                schema: "Hrm",
                table: "Employee");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                schema: "Hrm",
                table: "Relative",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
