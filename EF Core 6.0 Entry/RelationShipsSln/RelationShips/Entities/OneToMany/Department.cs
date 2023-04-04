using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationShips.Entities.OneToMany
{
    internal class Department
    {
        public int id { get; set; }
        public string name { get; set; }

        //NavProp => Many
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
