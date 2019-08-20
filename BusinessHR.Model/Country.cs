using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Model
{
    public class Country:BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
    }
}
