using InheritanceMapping.Contexts;
using InheritanceMapping.Entities;

namespace InheritanceMapping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using CompanyDbContext dbContext = new CompanyDbContext();

            FullTime fullTime = new FullTime()
            {
                Name = "Foo",
                Age = 30,
                Address = "Cairo",
                Salary = 4_000,
                StartDate = DateTime.Now,
            };
            PartTime partTime = new PartTime() 
            { 
                Name= "Foo2",
                Age=30,
                Address="Giza",
                HourRate=100,
                CountOfHour=30,
            };

            //dbContext.Add(partTime);
            dbContext.Employees.Add(partTime);
            //dbContext.Add(fullTime);
            dbContext.Employees.Add(fullTime);
            dbContext.SaveChanges();

            //var Full = from fulTime in dbContext.FullTimeEmployee
            //           select fulTime;

            //var Part = from partTim in dbContext.PartTimeEmployee
            //           select partTim;

            var employees = from employee in dbContext.Employees select employee;

            foreach (var item in employees.OfType<FullTime>())
            {
                Console.WriteLine($"{item.Name} ||| {item.Salary}");
            }

            Console.WriteLine("=================");
            foreach (var item in employees.OfType<PartTime>())
            {
                Console.WriteLine($"{item.Name} ||| {item.HourRate}");
            }
        }
    }
}