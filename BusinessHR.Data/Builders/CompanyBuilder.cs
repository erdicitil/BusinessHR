using BusinessHR.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Data.Builders
{
    public class CompanyBuilder
    {
        public CompanyBuilder(EntityTypeConfiguration<Company> builder)
        {

            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Phone).HasMaxLength(20);
            builder.Property(b => b.Address).HasMaxLength(500);

            builder.HasOptional(a => a.Country).WithMany(b => b.Companies).HasForeignKey(a => a.CountryId);
            builder.HasOptional(a => a.City).WithMany(b => b.Companies).HasForeignKey(a => a.CityId);
            builder.HasOptional(a => a.Region).WithMany(b => b.Companies).HasForeignKey(a => a.RegionId);
        }
    }
}
