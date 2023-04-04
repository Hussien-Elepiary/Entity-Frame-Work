using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationShips.Entities.OneToMany
{
    internal class Employee
    {
        [Key]
        public int EmpID { get; set; }

        public string Name { get; set; }

        //To Control the Column Data
        public int departmentid { get; set; }

        //NavProp => one
        //Convention
        //to get Dept Data
        public Department Department { get; set; }
    }
}
