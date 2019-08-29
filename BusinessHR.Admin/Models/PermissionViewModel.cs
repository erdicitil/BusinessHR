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
        [MaxLength(50)]
        [Display(Name = "İzin Türü")]
        public Guid PermissionTypeId { get; set; }
        public string PermissionTypeName { get; set; }
       
    }
}