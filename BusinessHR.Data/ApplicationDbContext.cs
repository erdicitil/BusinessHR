using BusinessHR.Data.Builders;
using BusinessHR.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(): base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
       
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PermissionType> PermissionTypes { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
            new CertificateBuilder(modelBuilder.Entity<Certificate>());
            new CityBuilder(modelBuilder.Entity<City>());
            new CompanyBuilder(modelBuilder.Entity<Company>());
            new CountryBuilder(modelBuilder.Entity<Country>());
            new DepartmentBuilder(modelBuilder.Entity<Department>());
            new EmployeeBuilder(modelBuilder.Entity<Employee>());
            new PermissionBuilder(modelBuilder.Entity<Permission>());
            new PermissionTypeBuilder(modelBuilder.Entity<PermissionType>());
            new PositionBuilder(modelBuilder.Entity<Position>());
            new RegionBuilder(modelBuilder.Entity<Region>());
            new SalaryBuilder(modelBuilder.Entity<Salary>());
        }

       
    }
}
