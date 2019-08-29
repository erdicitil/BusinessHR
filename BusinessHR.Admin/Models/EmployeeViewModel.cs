using BusinessHR.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessHR.Admin.Models
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }
        [MaxLength(100)]
        [Required]
        [Display(Name = "Adı")]
        public string FirstName { get; set; }
        [MaxLength(100)]
        [Required]
        [Display(Name = "Soyadı")]
        public string LastName { get; set; }
        [MaxLength(200)]
        [Display(Name = "FullName")]
        public string FullName { get { return FirstName + " " + LastName; } }
        [MaxLength(200)]
        [Display(Name = "Fotoğraf")]
        public string Photo { get; set; }
        [Display(Name = "Cinsiyet")]
        [Required]
        public Gender Gender { get; set; }
        [Display(Name = "Doğum Tarihi")]
        [Required]
        public DateTime DateOfBirth { get; set; }
        [MaxLength(11)]
        [Required]
        [Display(Name = "Kimlik Numarası")]
        public int IdentityNumber { get; set; }
        [MaxLength(20)]
        [Display(Name = "Telefon Numarası")]
        [Required]
        public string Mobile { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Uyruğu")]
        public string Nationality { get; set; }
        [MaxLength(500)]
        [Display(Name = "Adres")]
        [Required]
        public string Address { get; set; }
        [MaxLength(200)]
        [Display(Name = "Departman")]
        [Required]
        public Guid DepartmentId { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "Departman Adı")]
        public Department DepartmentName { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "Unvanı")]
        public Guid PositionId { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "Unvan Adı")]
        public Position PositionName { get; set; }
        [Required]
        [MaxLength(4000)]
        [Display(Name = "Açıklama")]
        public string Title { get; set; }
        [MaxLength(100)]
        [Display(Name = "Çalışma Durumu")]
        public WorkStatus WorkStatus { get; set; }
        [Display(Name = "Çalışma Türü")]
        public WorkType WorkType { get; set; }

        [Display(Name = "İşe Başlangıç Tarihi")]
        [Required]
        public DateTime CompanyWorkStartDate { get; set; }

        [Display(Name = "İşten Ayrılış Tarihi")]
        public DateTime CompanyWorkEndDate { get; set; }
        [MaxLength(200)]
        [Display(Name = "Maaşı")]

        public Guid SalaryId { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "Maaş Miktarı")]
        

        public virtual Salary SalaryDurum { get; set; }
        
        [MaxLength(200)]
        [Display(Name = "Aldığı Sertifikalar")]
        public Guid? CertificateId { get; set; }
        [MaxLength(200)]
        [Display(Name = "Sertifika Adı")]
        public virtual Certificate CertificateName { get; set; }
        [Display(Name = "Ülke")]
        public Guid CountryId { get; set; }

        [Display(Name = "Ülke Adı")]
        public string CountryName { get; set; }
        public Guid CityId { get; set; }
        [Display(Name = "Şehir Adı")]
        public string CityName { get; set; }
        public Guid RegionId { get; set; }
        [Display(Name = "İlçe Adı")]
        public virtual Region RegionName { get; set; }

    }
    
}