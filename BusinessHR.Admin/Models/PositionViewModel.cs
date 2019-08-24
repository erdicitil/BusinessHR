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
        [MaxLength(50)]
        [Display(Name = "Pozisyon")]
        public string Name { get; set; }
        [MaxLength(150)]
        [Display(Name = "Bölüm Adı")]
        public Guid DepartmentId { get; set; }
        
    }
}