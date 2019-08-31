using BusinessHR.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessHR.Admin.Models
{
    public class CompanyViewModel
    {
        public Guid Id { get; set; }
        [MaxLength(100)]
        [Required]
        [Display(Name = "Firma Adı")]
        public string Name { get; set; }
        [MaxLength(20)]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
        [MaxLength(500)]
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [Display(Name = "Ülke")]
        public Guid CountryId { get; set; }
        [Display(Name = "Ülke Adı")]
        public string CountryName { get; set; }
        [Display(Name = "Şehir")]
        public Guid CityId { get; set; }
        [Display(Name = "Şehir Adı")]
        public string CityName { get; set; }
        [Display(Name = "İlçe")]
        public Guid RegionId { get; set; }
       
        [Display(Name = "İlçe Adı")]
        public string RegionName { get; set; }
    }
}