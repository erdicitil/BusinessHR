using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Model
{
    public class Permission:BaseEntity
    {      
        public DateTime PermissionStartDate { get; set; }
        public DateTime PermissionEndDate { get; set; }
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public string PermissionTime { get; set; }
        public Guid PermissionTypeId { get; set; }
        public virtual PermissionType PermissionType { get; set; }
    }
}
