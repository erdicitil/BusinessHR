using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessHR.Admin.Models
{
    public class PermissionTypeViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "İzin Türü")]
        public string Name { get; set; }
    }
}