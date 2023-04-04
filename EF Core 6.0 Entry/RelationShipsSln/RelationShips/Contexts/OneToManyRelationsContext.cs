using Microsoft.EntityFrameworkCore;
using RelationShips.Entities.OneToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationShips.Contexts
{
    internal class OneToManyRelationsContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseSqlServer($"Server = .; DataBase = EFCoreRelationShips; Trusted_connection = true");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(E => 
            {
                //To Control Delete And Update Rule
               E.HasOne(e=>e.Department)
                .WithMany(D=>D.Employees)
                .OnDelete(DeleteBehavior.SetNull);
            });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }
    }
}
