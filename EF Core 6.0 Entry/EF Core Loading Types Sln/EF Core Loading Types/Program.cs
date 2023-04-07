using EF_Core_Loading_Types.Contexts;
using EF_Core_Loading_Types.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Loading_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using MiniCompanyDbContext context = new MiniCompanyDbContext();

            #region Explicit Loading
            //var employee = (from E in context.Employees
            //                where E.id == 3
            //                select E).FirstOrDefault();
            //// 1. Explixcit Loading
            //context.Entry(employee).Reference(E=>E.Department).Load();

            //Console.WriteLine($"EmployeeName: {employee?.name ?? "N/A"}, Department: {employee?.Department?.Name ?? "No Deparment"}");

            //var Deparment = (from D in context.Departments
            //                 where D.Id == 1
            //                 select D).FirstOrDefault();

            //// 1. Explixcit Loading
            //context.Entry(Deparment).Collection(E => E.Employees).Load();

            //Console.WriteLine($"DepartmetName: {Deparment?.Name ?? "N/A"}");

            //foreach (var Emp in Deparment.Employees)
            //    Console.WriteLine($"EmployeeId: {Emp.id}|| EmployeeName:{Emp.name}"); 
            #endregion


            // Get the Data From the needed Tables in one request thats good if the data is realy needed
            // but if the data is not requierd to be loaded every time thats not good 
            // Best use case : if the nav prop is One 
            #region Eager Loading
            //var employee = (from E in context.Employees.Include(E=>E.Department)//if the department have nav prop for otherTable .ThenInclude(D=>D.Test)
            //                where E.id == 3
            //                select E).FirstOrDefault();


            //Console.WriteLine($"EmployeeName: {employee?.name ?? "N/A"}, Department: {employee?.Department?.Name ?? "No Deparment"}");


            //var Deparment = (from D in context.Departments.Include(D => D.Employees)
            //                 where D.Id == 1
            //                 select D).FirstOrDefault();

            //Console.WriteLine($"DepartmetName: {Deparment?.Name ?? "N/A"}");

            //foreach (var Emp in Deparment.Employees)
            //    Console.WriteLine($"EmployeeId: {Emp.id}|| EmployeeName:{Emp.name}");
            #endregion


            // Get the data in 2 requests like the Explicit loading But went you request the Data needed 
            // you can say its Emplicit Loading 
            // Best Use Case : if the nav prop is Many
            #region Lazy Loading
            //var employee = (from E in context.Employees
            //                where E.id == 3
            //                select E).FirstOrDefault();


            //Console.WriteLine($"EmployeeName: {employee?.name ?? "N/A"}, Department: {employee?.Department?.Name ?? "No Deparment"}");


            //var Deparment = (from D in context.Departments
            //                 where D.Id == 1
            //                 select D).FirstOrDefault();

            //Console.WriteLine($"DepartmetName: {Deparment?.Name ?? "N/A"}");

            //foreach (var Emp in Deparment.Employees)
            //    Console.WriteLine($"EmployeeId: {Emp.id}|| EmployeeName:{Emp.name}");
            #endregion
        }
    }
}