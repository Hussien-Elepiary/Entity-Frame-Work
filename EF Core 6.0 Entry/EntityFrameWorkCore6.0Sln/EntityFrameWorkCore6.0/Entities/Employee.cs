using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkCore6._0.Entities
{
    // EF Core supports 4 ways for mapping classes to (Table / View)
    // 1. by convention
    // 2. Data Annotation (Set Of Attributes)
    // 3. Fluent APIs ( Override OnModelCreating() in DbContext )     Common Use: (Composite PK, Default Value For a Column) or i don`t have the sorce code for the Class 
    // 4. Config Class Per Entity - Organize 3rdWay

    /// <summary>
    /// POCO Class
    /// Plain old clr object 
    /// 
    /// no pehavior or functtionality
    /// </summary>
    #region By Convension
    //internal class Employee
    //{
    //    public int Id { get; set; } // Id Prop Or EmployeeId Will be converted to auto increment PK
    //    public string? EmpName { get; set; } // Nvarchar(Max) , nullable
    //    public decimal Salary { get; set; } //Value Type Not null
    //    public int? Age { get; set; }// nullable
    //} 
    #endregion

    #region Data Annotation (Set Of Attributes)
    internal class Employee
    {
        /// <summary>
        /// note:
        /// 
        /// not all Attributes are Mapped in the database the are a validation for the FrontEnd and Handling Data
        /// like [Range] / [Email] / [PassWord]
        /// </summary>

        [Key] // to make it PK if i change the naming  
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // If i want the Id to Increment (1,1)
        public int EmpId { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        //[MaxLength(50)]
        [StringLength(50,MinimumLength =10)]
        public string? EmpName { get; set; } // Nvarchar(Max) , nullable

        //[Column(TypeName = "money")]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; } //Value Type Not null

        [Range(22,50)]
        public int? Age { get; set; }// nullable

        //[DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        //[DataType(DataType.PhoneNumber)]
        //[Phone]
        //public string PhoneNumber { get; set; }

        //[DataType(DataType.Password)]
        //public string PassWord { get; set; }
    }
    #endregion

}
