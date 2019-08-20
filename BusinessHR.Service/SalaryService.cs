using BusinessHR.Data;
using BusinessHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Service
{
    public class SalaryService : ISalaryService
    {
        private readonly IRepository<Salary> salaryRepository;
        private readonly IUnitOfWork unitOfWork;
        public SalaryService(IRepository<Salary> salaryRepository, IUnitOfWork unitOfWork)
        {
            this.salaryRepository = salaryRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(Guid id)
        {
            return salaryRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var salary = salaryRepository.Get(id);
            if (salary != null)
            {
                salaryRepository.Delete(salary);
                unitOfWork.SaveChanges();
            }
        }

        public Salary Get(Guid id)
        {
            return salaryRepository.Get(id);
        }

        public IEnumerable<Salary> GetAll()
        {
            return salaryRepository.GetAll();
        }

        public void Insert(Salary salary)
        {
            salaryRepository.Insert(salary);
            unitOfWork.SaveChanges();
        }

        public void Update(Salary salary)
        {
            salaryRepository.Update(salary);
            unitOfWork.SaveChanges();
        }
    }

    public interface ISalaryService
    {
        IEnumerable<Salary> GetAll();
        Salary Get(Guid id);
        void Insert(Salary salary);
        void Update(Salary salary);
        void Delete(Guid id);
        bool Any(Guid id);


    }
}
