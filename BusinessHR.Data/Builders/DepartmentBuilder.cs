﻿using BusinessHR.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Data.Builders
{
    public class DepartmentBuilder
    {
        public DepartmentBuilder(EntityTypeConfiguration<Department> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            builder.HasOptional(a => a.Company).WithMany(b => b.Departments).HasForeignKey(a => a.Company);
        }
    }
}
