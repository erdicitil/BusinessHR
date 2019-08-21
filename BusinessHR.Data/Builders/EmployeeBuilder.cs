using BusinessHR.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Data.Builders
{
    public class EmployeeBuilder
    {
        public EmployeeBuilder(EntityTypeConfiguration<Employee> builder)
        {
            builder.Property(b => b.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(b => b.LastName).HasMaxLength(100).IsRequired();
            builder.Ignore(b => b.FullName);
            builder.Property(b => b.Photo).HasMaxLength(200);
            builder.Property(b => b.Mobile).HasMaxLength(20).IsRequired();
            builder.Property(b => b.Nationality).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Address).HasMaxLength(100).IsRequired();
            builder.HasOptional(a => a.Department).WithMany(b => b.Employees).HasForeignKey(a => a.Department);
            builder.HasOptional(a => a.Position).WithMany(b => b.Employees).HasForeignKey(a => a.Position);
            builder.Property(b => b.Title).HasMaxLength(4000).IsRequired();
            builder.Property(b => b.WorkStatus).HasMaxLength(100).IsRequired();
            builder.HasOptional(a => a.Salary).WithMany(b => b.Employees).HasForeignKey(a => a.Salary);
            builder.HasOptional(a => a.Certificate).WithMany(b => b.Employees).HasForeignKey(a => a.Certificate);

        }
    }
}
