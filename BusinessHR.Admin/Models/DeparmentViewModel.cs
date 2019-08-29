using BusinessHR.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessHR.Admin.Models
{
    public class DeparmentViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Departman Adı")]
        public string Name { get; set; }
        [Display(Name = "Firma")]
        public Guid CompanyId { get; set; }
        
        [Display(Name = "Firma Adı")]
        public virtual Company CompanyName { get; set; }
    }
}