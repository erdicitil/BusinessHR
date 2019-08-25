using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Model
{
    public enum WorkType
    {
        [Display(Name = "Tam Zamanlı")]
        FullTime = 1,

        [Display(Name = "Yarı Zamanlı")]
        PartTime = 2,

        [Display(Name = "Stajyer")]
        Intern = 3,

        [Display(Name = "Diğer Durumlar")]
        Other = 4

    }
}
