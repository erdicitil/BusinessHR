
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessHR.Admin.Models
{
    public class RegionViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "İlçe Adı")]
        public string Name { get; set; }
        [MaxLength(100)]
        [Display(Name = "Şehir")]
        public Guid CityId { get; set; }
        [Display(Name = "Şehir Adı")]
        public string CityName { get; set; }

    }
}