using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Model
{
    public class Position:BaseEntity
    {
        public string Name { get; set; }
        
        public virtual ICollection<Department> Department { get; set; }
    }
}
