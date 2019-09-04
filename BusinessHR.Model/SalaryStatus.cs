using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Model
{
    public enum SalaryStatus
    
    {
        [Display(Name = "Ödenmedi")]

        UnPaid = 1,

        [Display(Name = "Ödendi")]

        Paid = 2,
    
    }
}
