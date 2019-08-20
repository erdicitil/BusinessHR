using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Model
{
    public class Salary:BaseEntity
    {
      
        public decimal Maas { get; set; }
        public decimal BrutMaas { get; set; }
        public decimal NetMaas { get; set; }
        public decimal AGI { get; set; }
        public decimal KGV { get; set; }
        public decimal Odenen { get; set; }
        public string Durum { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

    }
}
