using EntityFrameWorkCore6._0.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkCore6._0.Contexts
{
    internal class EntrpriseDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          //=>optionsBuilder.UseSqlServer($"Data Source = DESKTOP-G2BCMH5/MSSQLSERVER03; initial Catalog = EnterpriseDB; integrated security = true"); // Thats a way to connect
         => optionsBuilder.UseSqlServer($"Server = .; DataBase = EnterpriseDB; Trusted_connection = true");

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
