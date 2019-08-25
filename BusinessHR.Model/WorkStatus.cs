using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Model
{
    public enum WorkStatus
    {
        [Display(Name = "Çalışıyor")]

        Working = 1,

        [Display(Name = "Ayrıldı")]

        Left = 2,
    }
}
