using EntityFrameWorkCore6._0.Contexts;
using EntityFrameWorkCore6._0.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore6._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            using EntrpriseDBContext dbContext = new EntrpriseDBContext(); // is a syntax Sugar For (Try{ ... }Finally{ Finaly Handles the Unmanged resorces like DB connections dbContext.Dispose() }) 

            //dbContext.Database.Migrate(); // to make the migration

            //Crud Oprations
            //insert

            Employee E1 = new Employee() { EmpName = "Ahemd", Age = 30, Salary = 4_000 , Email = "Ahmed@gmail.com"};
            Employee E2 = new Employee() { EmpName = "Hussein", Age = 24, Salary = 3_000 , Email = "Hussein@gmail.com"};

            #region insert
            //Console.WriteLine(dbContext.Entry(E1).State); // Deatched

            ////Add to Local 
            //dbContext.Employees.Add(E1);
            //dbContext.Add(E2); // EF Core 3.1
            ////dbContext.Set<Employee>().Add(E2);
            ////dbContext.Entry(E2).State = EntityState.Added;

            //Console.WriteLine(dbContext.Entry(E1).State); // Added

            ////Add To Remote (DataBase)
            //dbContext.SaveChanges();

            //Console.WriteLine(dbContext.Entry(E1).State); // UnChanged

            //Console.WriteLine("++++++++++++++++++");
            //Console.WriteLine($"Employee 01 :{E1.EmpId}");
            //Console.WriteLine($"Employee 02 :{E2.EmpId}");
            #endregion

            #region Retreive(Select)
                var employee = (from emp in dbContext.Employees
                               where emp.EmpId == 2
                               select emp).FirstOrDefault();

                Console.WriteLine(employee?.EmpName ?? "N\\A");

            #endregion

            #region Update
            //if (employee != null )
            //{
            //    Console.WriteLine(dbContext.Entry(employee).State); // UnChanged 
            //    employee.EmpName = "Aly";
            //    Console.WriteLine(dbContext.Entry(employee).State); // Modified
            //    dbContext.SaveChanges();
            //    Console.WriteLine(dbContext.Entry(employee).State); // UnChanged 
            //}
            //else
            //{
            //    Console.WriteLine("There is no employee With that ID ");
            //}
            #endregion

            #region Delete
            //if (employee != null)
            //{
            //    Console.WriteLine(dbContext.Entry(employee).State); // UnChanged 
            //    dbContext.Employees.Remove(employee);
            //    Console.WriteLine(dbContext.Entry(employee).State); // Deleted
            //    dbContext.SaveChanges();
            //    Console.WriteLine(dbContext.Entry(employee).State); // Deatched 
            //}
            //else
            //{
            //    Console.WriteLine("There is no employee With that ID ");
            //}
            #endregion
        }
    }
}