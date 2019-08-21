using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Model
{
    public class Company:BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public Guid CountryId { get; set; }
        public virtual Country Country { get; set; }

        public Guid CityId { get; set; }
        public virtual City City { get; set; }
        public Guid RegionId { get; set; }
        public virtual Region Region { get; set; }
    }
}
