using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Model
{
    public class PermissionType:BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
