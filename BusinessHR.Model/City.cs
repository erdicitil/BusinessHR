using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Model
{
    public class City:BaseEntity
    {
        public string Name { get; set; }
        public Guid CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Region> Regions { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
    }
}
