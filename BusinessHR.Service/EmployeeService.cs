using BusinessHR.Data;
using BusinessHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Service
{
    
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> employeeRepository;
        private readonly IUnitOfWork unitOfWork;
        public EmployeeService(IRepository<Employee> employeeRepository, IUnitOfWork unitOfWork)
        {
            this.employeeRepository = employeeRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(Guid id)
        {
            return employeeRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Employee Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Employee city)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee city)
        {
            throw new NotImplementedException();
        }
    }

    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee Get(Guid id);
        void Insert(Employee city);
        void Update(Employee city);
        void Delete(Guid id);
        bool Any(Guid id);


    }
}
