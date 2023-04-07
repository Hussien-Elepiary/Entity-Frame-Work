using EF_Core_Loading_Types.Contexts;
using EF_Core_Loading_Types.Entities;
using EF_Core_Loading_Types.Entities.NorthWind;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace EF_Core_Loading_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using MiniCompanyDbContext context = new MiniCompanyDbContext();
            using NorthwindContext northwindContext = new NorthwindContext();

            #region Loading 
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
            #endregion

            #region ViewMapping

            //var result = context.Employees.FromSqlRaw("Select * From EmployeeDeptView");

            //foreach (var item in context.EmployeeDeptView)
            //{
            //    Console.WriteLine($"Employee {item.EmpName}");
            //}

            #endregion

            #region Tracing And NoTracing
            ///Tracing is thing that trace the state of data if it`s updated or deleted or a new data over all
            ///to make sure that your data is sync with the data base 
            ///ue can stop tracing the data with this command {.AsNoTracking()} like the Following 
            //var employee = (from E in context.Employees
            //                where E.id == 3
            //                select E).AsNoTracking().FirstOrDefault();
            ///Use .AsNoTracking() if you are going to just view the data only 
            #endregion

            #region MaxBy() MinBy()
            /// MaxBy() MinBy() Agrregate Functions

            //Employee[] employees = 
            //{
            //    new Employee() { id = 1, name = "Ahmed", DepartmentId = 1 ,Salary = 1000},
            //    new Employee() { id = 2, name = "Saly", DepartmentId = 2 ,Salary = 5000},
            //    new Employee() { id = 3, name = "Mariam", DepartmentId = 1 ,Salary = 10000},
            //};


            /// System.ArgumentException: 'At least one object must implement IComparable.'
            //employees.Max();

            //Console.WriteLine(employees.MaxBy(e => e.Salary).name); ;
            #endregion

            #region Local and Remote
            // this command gose to the database every time to check for the data
            //if (northwindContext.Products.Any(P => P.UnitsInStock == 0))
            //{
            //    Console.WriteLine("There is at least one product is out of stock");
            //}
            // this command gose to the local(chached data) if there is no data it gose to the remote(data base)
            //if (northwindContext.Products.Local.Any(P => P.UnitsInStock == 0))
            //    Console.WriteLine("There is at least one product is out of stock");
            //else if (northwindContext.Products.Any(P => P.UnitsInStock == 0))
            //    Console.WriteLine("There is at least one product is out of stock");
            //else
            //    Console.WriteLine("There is no product out of stock");

            //there is only one method that works like the past example it gose to the loacl first then check in the remote if there is no data 
            //var result = northwindContext.Products.Find(1);
            //var result = northwindContext.Find<Product>(1);

            // to set the data from remot to local use the following command 
            // context.tablename.Load() like the following
            //northwindContext.Products.Load();
            #endregion

            #region Runinng SQL Query

            ///1. DQL Statment : FromSqlRaw() FromSqlInterpolated()

            //var Categories = northwindContext.Categories.FromSqlRaw("select * from categories");

            //int count = 2;
            //Categories = northwindContext.Categories.FromSqlInterpolated($"select top({count}) * from categories");

            //foreach (var category in Categories)
            //Console.WriteLine(category);

            /// 2. DML statment : ExecuteSqlRaw() ExecuteSqlInterpolated()

            //northwindContext.Database.ExecuteSqlRaw("update categories set categoryName = 'New' where categoryId = 2");
            //northwindContext.Database.ExecuteSqlInterpolated($"update categories set categoryName = 'New' where categoryId = 2");

            #endregion

            #region Running stored Proc

            //making this manully will consume a lot of time
            //var products = northwindContext.Products.FromSqlRaw("Exec [Sales by Year] @Beginning_Date, @Ending_Date",);

            // you can use the extention (EF Core Power Tools) and after that make reverse engneer for the stordProc then use it like the following 
            //var Proc = new NorthwindContextProcedures(northwindContext);

            //var shipment = Proc.SalesbyYearAsync(new DateTime(1998,1,1),new DateTime(1998,2,1));

            //foreach (var s in shipment.Result)
            //{
            //    Console.WriteLine(s.OrderID);
            //}

            #endregion
        }
    }
}