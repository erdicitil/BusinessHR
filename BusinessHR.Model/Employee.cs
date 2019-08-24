using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Model
{
    public class Employee:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string Photo { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int IdentityNumber { get; set; }
        public string Mobile { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department  { get; set; }
        public Guid PositionId { get; set; }
        public Position Position { get; set; }
        public string Title { get; set; }
        public string WorkStatus { get; set; }
        public DateTime CompanyWorkStartDate { get; set; }
        public DateTime? CompanyWorkEndDate { get; set; }
        public Guid SalaryId { get; set; }
        public virtual Salary Salary { get; set; }
        public Guid? CertificateId { get; set; }
        public virtual Certificate Certificate { get; set; }
        public Guid? CountryId { get; set; }
        public virtual Country Country { get; set; }
        public Guid? CityId { get; set; }
        public virtual City City { get; set; }
        public Guid? RegionId { get; set; }
        public virtual Region Region { get; set; }





    }
}
