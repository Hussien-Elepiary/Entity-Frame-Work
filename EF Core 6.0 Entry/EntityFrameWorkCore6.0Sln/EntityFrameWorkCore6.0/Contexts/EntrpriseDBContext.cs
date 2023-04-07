using DepatmentClass;
using EntityFrameWorkCore6._0.Config;
using EntityFrameWorkCore6._0.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /// Example: modelBuilder.Entity<Employee>().Property("Address").HasDefaultValue("Cairo").IsRequired(true);

            ///modelBuilder.Entity<Department>().ToView("Departments");
            ///modelBuilder.Entity<Department>().ToTable("Departments");

            ///modelBuilder.Entity<Department>().HasKey("DebtID");
            ///modelBuilder.Entity<Department>().HasKey(nameof(Department.DebtID));

            ///modelBuilder.Entity<Department>().HasKey(D => D.DebtID); //PK

            ///modelBuilder.Entity<Department>().Property(D => D.DebtID)
            ///                                    .UseIdentityColumn(10,10);// Custom IdentityCol

            ///modelBuilder.Entity<Department>().Property(D => D.Name)
            ///                                    .HasColumnName("DeptName") // Set A custom name in the Data Base
            ///                                    .HasColumnType("varchar")
            ///                                    .HasDefaultValue("Test")
            ///                                    .HasMaxLength(50)
            ///                                    .IsRequired(false); //.HasAnnotation("MaxLength", 50)

            ///modelBuilder.Entity<Department>().Property(D => D.DateOfCreation)
            ///                                    .HasDefaultValueSql("GetDate()");  //.HasDefaultValue(DateTime.Now);

            /// EF Core 3.1 Feature
            ///modelBuilder.Entity<Department>(E =>
            ///{
            ///    E.HasKey(D => D.DebtID); //PK
            ///    E.Property(D => D.DebtID)
            ///        .UseIdentityColumn(10, 10);// Custom IdentityCol
            ///    E.Property(D => D.Name)
            ///        .HasColumnName("DeptName") // Set A custom name in the Data Base
            ///        .HasColumnType("varchar")
            ///        .HasDefaultValue("Test")
            ///        .HasMaxLength(50)
            ///        .IsRequired(false); //.HasAnnotation("MaxLength", 50)
            ///    E.Property(D => D.DateOfCreation)
            ///        .HasDefaultValueSql("GetDate()");  //.HasDefaultValue(DateTime.Now);
            ///});

            modelBuilder.ApplyConfiguration(new DepartmentConfig());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }
        //public DbSet<Department> Departments { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
