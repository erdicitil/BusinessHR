using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Model
{
    public class Region:BaseEntity
    {
        public string Name { get; set; }
        public Guid CityId { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        
        public virtual ICollection<Company> Companies { get; set; }
        
    }
}

