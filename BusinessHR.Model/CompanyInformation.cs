using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Model
{
    public class CompanyInformation:BaseEntity
    {
        public string CompanyName { get; set; }
        public string DepartmentName { get; set; }
        public string Title { get; set; }
    }
}
