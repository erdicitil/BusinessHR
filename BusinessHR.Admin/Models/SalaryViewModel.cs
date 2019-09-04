using BusinessHR.Model;
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
        [Display(Name = "Ödeme Tarihi")]
        public DateTime SalaryDate { get; set; }
        [Required]
        [Display(Name = "Brüt Maaş")]
        public decimal BrutMaas { get; set; }
        [Required]
        [Display(Name = "SGK Primi")]
        public decimal SGKPrim { get; set; }
        [Required]
        [Display(Name = "İşsizlik Sigortası")]
        public decimal IssizlikSigortasi { get; set; }
        [Required]
        [Display(Name = "Damga Vergisi")]
        public decimal DamgaVergisi { get; set; }
        [Required]
        [Display(Name = "AGİ")]
        public decimal AGI { get; set; }
        [Required]
        [Display(Name = "KGV")]
        public decimal KGV { get; set; }
        [Required]
        [Display(Name = "Net Maaş")]
        public decimal NetMaas { get; set; }
        
        [Display(Name = "Eklemeler")]
        public decimal Eklemeler { get; set; }
        
        [Display(Name = "Kesintiler")]
        public decimal Kesintiler { get; set; }
        
        [Display(Name = "Ödenen")]
        public decimal ToplamOdenen { get; set; }
        
        [Display(Name = "Maaş Durumu")]
        public SalaryStatus SalaryStatus { get; set; }
        [Required]
        [Display(Name = "Personel")]
        public Guid EmployeeId { get; set; }
        [Required]
        [Display(Name = "Personel Adı")]
        public string EmployeeName { get; set; }

        

    }
}