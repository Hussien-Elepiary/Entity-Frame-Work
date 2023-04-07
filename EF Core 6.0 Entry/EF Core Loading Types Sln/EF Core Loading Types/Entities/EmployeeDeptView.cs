using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Loading_Types.Entities
{
    [Keyless]
    public class EmployeeDeptView
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }
}
