using BusinessHR.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Data
{
    public class PermissionBuilder
    {
        public PermissionBuilder(EntityTypeConfiguration<Permission> builder)
        {
            builder.Property(b => b.PermissionTime).HasMaxLength(100).IsRequired();
            builder.HasRequired(a => a.PermissionType).WithMany(b => b.Permissions).HasForeignKey(a => a.PermissionTypeId);
            builder.HasRequired(a => a.Employee).WithMany(b => b.Permissions).HasForeignKey(a => a.EmployeeId);

        }
    }
}
