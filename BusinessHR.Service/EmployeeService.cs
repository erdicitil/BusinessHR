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
            var employee = employeeRepository.Get(id);
            if (employee != null)
            {
                employeeRepository.Delete(employee);
                unitOfWork.SaveChanges();
            }
        }

        public Employee Get(Guid id)
        {
            return employeeRepository.Get(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return employeeRepository.GetAll();
        }

        public void Insert(Employee employee)
        {
            employeeRepository.Insert(employee);
            unitOfWork.SaveChanges();
        }

        public void Update(Employee employee)
        {
            employeeRepository.Update(employee);
            unitOfWork.SaveChanges();
        }
    }

    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee Get(Guid id);
        void Insert(Employee employee);
        void Update(Employee employee);
        void Delete(Guid id);
        bool Any(Guid id);


    }
}
