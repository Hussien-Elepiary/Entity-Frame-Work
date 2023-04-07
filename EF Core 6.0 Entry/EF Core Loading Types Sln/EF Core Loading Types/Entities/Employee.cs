using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Loading_Types.Entities
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }

        public decimal? Salary { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
