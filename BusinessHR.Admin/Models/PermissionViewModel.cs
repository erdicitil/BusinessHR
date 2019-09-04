using BusinessHR.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessHR.Admin.Models
{
    public class PermissionViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "İzin Başlangıç Tarihi")]
        public DateTime PermissionStartDate { get; set; }
        [Display(Name = "İzin Bitiş Tarihi")]
        public DateTime PermissionEndDate { get; set; }
        [Display(Name = "İzin Süresi")]
        public string PermissionTime { get; set; }
        
        [Display(Name = "İzin Türü")]
        public Guid PermissionTypeId { get; set; }
        [Display(Name = "İzin Türü Adı")]
        public string PermissionTypeName { get; set; }
        [Display(Name = "Personel")]
        public Guid EmployeeId { get; set; }
        [Display(Name = "Personel Adı")]
        public string EmployeeName { get; set; }

    }
}