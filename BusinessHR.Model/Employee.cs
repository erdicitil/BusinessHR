using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int IdentityNumber { get; set; }
        public string Mobile { get; set; }
        public string Nationality { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public string WorkStatus { get; set; }
        public DateTime CompanyStartDate { get; set; }
        public DateTime CompanyEndDate { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }


    }
}
