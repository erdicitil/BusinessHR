using BusinessHR.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Data.Builders
{
    public class RegionBuilder
    {
        public RegionBuilder(EntityTypeConfiguration<Region> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            builder.HasOptional(a => a.City).WithMany(b => b.Regions).HasForeignKey(a => a.City);

        }
    }
}
