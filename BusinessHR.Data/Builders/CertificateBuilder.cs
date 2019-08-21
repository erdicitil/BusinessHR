using BusinessHR.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Data.Builders
{
    public class CertificateBuilder
    {
        public CertificateBuilder(EntityTypeConfiguration<Certificate> builder)
        {

            builder.Property(b => b.Name).HasMaxLength(150).IsRequired();
        }
    }
}
