using InheritanceMapping.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceMapping.Contexts
{
    internal class CompanyDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server = .; DataBase = CompanyDB; Trusted_Connection = True");

        //TPH Table Per Hierarchy
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // will Delete one and edit the other one and add a new column (Discriminator)
            //The Problem in this Approuch is The null
            modelBuilder.Entity<FullTime>().HasBaseType<Employee>();
            modelBuilder.Entity<PartTime>().HasBaseType<Employee>();

            base.OnModelCreating(modelBuilder);
        }
        //Hint: TPH Can Be Called With either of the Following two ways (TPC) Way
        //TPC  Table Per Concrete Class
        //public DbSet<FullTime> FullTimeEmployee { get; set; }
        //public DbSet<PartTime> PartTimeEmployee { get; set; }

        //TPH Other Way
        public DbSet<Employee> Employees { get; set; }
    }
}
