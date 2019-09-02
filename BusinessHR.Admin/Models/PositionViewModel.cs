using BusinessHR.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessHR.Admin.Models
{
    public class PositionViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Pozisyon")]
        public string Name { get; set; }
        
        
        public Guid DepartmentId { get; set; }
        [Display(Name = "Bölüm Adı")]
        public string DepartmentName { get; set; }
        
    }
}