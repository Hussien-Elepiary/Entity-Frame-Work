using EntityFrameWorkCore6._0.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore6._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            EntrpriseDBContext dbContext = new EntrpriseDBContext();

            //dbContext.Database.Migrate(); // to make the migration
        }
    }
}