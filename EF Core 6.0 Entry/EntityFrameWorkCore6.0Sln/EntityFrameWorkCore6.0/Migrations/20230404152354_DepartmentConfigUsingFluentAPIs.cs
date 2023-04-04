using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameWorkCore6._0.Migrations
{
    public partial class DepartmentConfigUsingFluentAPIs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Departments",
                newName: "DebtID");

            migrationBuilder.AlterColumn<int>(
                name: "DebtID",
                table: "Departments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "10, 10")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCreation",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GetDate()");

            migrationBuilder.AddColumn<string>(
                name: "DeptName",
                table: "Departments",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "Test");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfCreation",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DeptName",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "DebtID",
                table: "Departments",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Departments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "10, 10");
        }
    }
}
