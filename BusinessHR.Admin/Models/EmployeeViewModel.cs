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
        [Display(Name = "Adı Soyadı")]
        public string FullName { get { return FirstName + " " + LastName; }  }
        
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
        public string IdentityNumber { get; set; }
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
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        
        [Display(Name = "Departman")]
        
        public Guid? DepartmentId { get; set; }
        
        
        [Display(Name = "Departman Adı")]
        public string DepartmentName { get; set; }
        
        
        [Display(Name = "Unvanı")]
        public Guid? PositionId { get; set; }
        
        
        [Display(Name = "Unvan Adı")]
        public string PositionName { get; set; }
        
        [MaxLength(4000)]
        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]
        public string Title { get; set; }
        
        [Display(Name = "Çalışma Durumu")]
        public WorkStatus WorkStatus { get; set; }
        [Display(Name = "Çalışma Türü")]
        public WorkType WorkType { get; set; }

        [Display(Name = "İşe Başlangıç Tarihi")]
        [Required]
        public DateTime CompanyWorkStartDate { get; set; }

        [Display(Name = "İşten Ayrılış Tarihi")]
        public DateTime? CompanyWorkEndDate { get; set; }
        
        [Display(Name = "Maaşı")]

        public Guid? SalaryId { get; set; }
        
        
        [Display(Name = "Maaş Miktarı")]
        public string SalaryPaid { get; set; }
        [Display(Name = "İzin")]
        public Guid? PermissionId { get; set; }
        

        
        [Display(Name = "İzin Tarihi")]
        public string PermissionStartDate { get; set; }


        [Display(Name = "Aldığı Sertifikalar")]
        public Guid? CertificateId { get; set; }
        
        [Display(Name = "Sertifika Adı")]
        public string CertificateName { get; set; }
        [Display(Name = "Ülke")]
        public Guid? CountryId { get; set; }

        [Display(Name = "Ülke Adı")]
        public string CountryName { get; set; }
        [Display(Name = "Şehir")]
        public Guid? CityId { get; set; }
        [Display(Name = "Şehir Adı")]
        public string CityName { get; set; }
        [Display(Name = "İlçe")]
        public Guid? RegionId { get; set; }
        [Display(Name = "İlçe Adı")]
        public string RegionName { get; set; }

    }
    
}