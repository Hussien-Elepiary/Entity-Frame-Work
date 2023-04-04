using Microsoft.EntityFrameworkCore;
using RelationShips.Entities.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationShips.Contexts
{
    internal class ManyToManyContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseSqlServer($"Server = .; DataBase = EFCoreRelationShips; Trusted_connection = true");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Can`t Configure Dirctly Need 3rd Table to be made Manualy 
            //modelBuilder.Entity<Student>().HasMany(S => S.Courses).WithMany(C => C.Students);
            //modelBuilder.Entity<Course>().HasMany(C => C.Students).WithMany(S => S.Courses);

            //Config After Making The Manual Table
            //modelBuilder.Entity<Student>().HasMany(S => S.StudentCourses).WithOne(SC => SC.Student);
            //modelBuilder.Entity<Course>().HasMany(C => C.CourseStudents).WithOne(SC => SC.Course);

            modelBuilder.Entity<StudentCourse>().HasKey(PK => new { PK.StudentId ,PK.CourseId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }
    }
}
