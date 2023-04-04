using DepatmentClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkCore6._0.Config
{
    internal class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> E)
        {
            E.HasKey(D => D.DebtID); //PK

            E.Property(D => D.DebtID)
                .UseIdentityColumn(10, 10);// Custom IdentityCol

            E.Property(D => D.Name)
                .HasColumnName("DeptName") // Set A custom name in the Data Base
                .HasColumnType("varchar")
                .HasDefaultValue("Test")
                .HasMaxLength(50)
                .IsRequired(false); //.HasAnnotation("MaxLength", 50)

            E.Property(D => D.DateOfCreation)
                .HasDefaultValueSql("GetDate()");  //.HasDefaultValue(DateTime.Now);
        }
    }
}
