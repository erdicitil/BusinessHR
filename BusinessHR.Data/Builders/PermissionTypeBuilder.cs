﻿using BusinessHR.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Data.Builders
{
    public class PermissionTypeBuilder
    {
        public PermissionTypeBuilder(EntityTypeConfiguration<PermissionType> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            

        }
    }
}
