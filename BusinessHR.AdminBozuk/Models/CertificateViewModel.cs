using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessHR.Admin.Models
{
    public class CertificateViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Sertifika Adı")]
        [MaxLength(150)]
        [Required]
        public string Name { get; set; }
    }
}