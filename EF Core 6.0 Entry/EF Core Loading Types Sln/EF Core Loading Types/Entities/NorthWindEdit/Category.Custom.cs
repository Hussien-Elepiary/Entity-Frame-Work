using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Loading_Types.Entities.NorthWind
{
    public partial class Category
    {
        public override string ToString()
        {
            return $"{CategoryName} ::: {Description}";
        }
    }
}
