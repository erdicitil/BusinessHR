using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Model
{
    public class Permission
    {
        public int Id { get; set; }
        public DateTime PermissionStartDate { get; set; }
        public DateTime PermissionEndDate { get; set; }
        public int PermissiveId { get; set; }
        public string PermissionTime { get; set; }
        public string PermissionType { get; set; }
    }
}
