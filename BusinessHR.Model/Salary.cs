using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Model
{
    public class Salary:BaseEntity
    {
      
        public DateTime SalaryDate { get; set; }
        public decimal BrutMaas { get; set; }
        public decimal SGKPrim { get; set; }
        public decimal IssizlikSigortasi { get; set; }
        public decimal DamgaVergisi { get; set; }
        public decimal AGI { get; set; }
        public decimal KGV { get; set; }
       
        public decimal NetMaas { get; set; }
        public decimal Eklemeler { get; set; }
        public decimal Kesintiler { get; set; }
        public decimal ToplamOdenen { get; set; }
        public SalaryStatus SalaryStatus { get; set; }
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        
        

    }
}
