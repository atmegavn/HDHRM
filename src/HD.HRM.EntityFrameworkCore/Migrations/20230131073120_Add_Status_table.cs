using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HD.HRM.Migrations
{
    public partial class Add_Status_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Status",
                newName: "Status",
                newSchema: "Hrm");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Hrm",
                table: "Status",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "Hrm",
                table: "Status",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newid()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Status",
                schema: "Hrm",
                newName: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Status",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Status",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "newid()");
        }
    }
}
