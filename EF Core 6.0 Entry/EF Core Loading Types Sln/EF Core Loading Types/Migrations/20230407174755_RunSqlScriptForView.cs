using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core_Loading_Types.Migrations
{
    public partial class RunSqlScriptForView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create view EmployeeDeptView
                                    With Encryption 
                                    As	
	                                    select E.id EmpID ,E.name EmpName , D.Id DeptId, D.Name DeptName 
	                                    from Employees E , Departments D
	                                    Where D.Id = E.DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Drop view EmployeeDeptView");
        }
    }
}
