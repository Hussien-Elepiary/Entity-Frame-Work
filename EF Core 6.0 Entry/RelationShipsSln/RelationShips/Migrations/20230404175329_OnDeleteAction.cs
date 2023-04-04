using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RelationShips.Migrations
{
    public partial class OnDeleteAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_departmentid",
                table: "Employees");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_departmentid",
                table: "Employees",
                column: "departmentid",
                principalTable: "Departments",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_departmentid",
                table: "Employees");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_departmentid",
                table: "Employees",
                column: "departmentid",
                principalTable: "Departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
