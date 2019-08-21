using BusinessHR.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Data.Builders
{
    public class SalaryBuilder
    {
        public SalaryBuilder(EntityTypeConfiguration<Salary> builder)
        {
            builder.Property(b => b.Durum).HasMaxLength(100).IsRequired();
        }
    }
}
