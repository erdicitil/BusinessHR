using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Model
{
    public class Department:BaseEntity
    { 
        public string Name { get; set; }
        public Guid CompanyId { get; set; }
        
        public virtual Company Company { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
