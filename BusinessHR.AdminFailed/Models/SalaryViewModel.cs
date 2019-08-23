using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessHR.Admin.Models
{
    public class SalaryViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Maaş")]
        public decimal Maas { get; set; }
        [Required]
        [Display(Name = " Brüt Maaş")]
        public decimal BrutMaas { get; set; }
        [Required]
        [Display(Name = " Net Maaş")]
        public decimal NetMaas { get; set; }
        [Display(Name = "AGİ")]
        public decimal AGI { get; set; }
        [Display(Name = "Geçici Vergi")]
        public decimal KGV { get; set; }
        [Display(Name = "Ödenen Miktar")]
        public decimal Odenen { get; set; }
        [Display(Name = "Durum")]
        public string Durum { get; set; }
    }
}