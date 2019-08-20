using BusinessHR.Data;
using BusinessHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> departmentRepository;
        private readonly IUnitOfWork unitOfWork;
        public DepartmentService(IRepository<Department> departmentRepository, IUnitOfWork unitOfWork)
        {
            this.departmentRepository = departmentRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(Guid id)
        {
            return departmentRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var department = departmentRepository.Get(id);
            if (department != null)
            {
                departmentRepository.Delete(department);
                unitOfWork.SaveChanges();
            }
        }

        public Department Get(Guid id)
        {
            return departmentRepository.Get(id);
        }

        public IEnumerable<Department> GetAll()
        {
            return departmentRepository.GetAll();
        }

        public void Insert(Department department)
        {
            departmentRepository.Insert(department);
            unitOfWork.SaveChanges();
        }

        public void Update(Department department)
        {
            departmentRepository.Update(department);
            unitOfWork.SaveChanges();
        }
    }
    public interface IDepartmentService
    {
        IEnumerable<Department> GetAll();
        Department Get(Guid id);
        void Insert(Department department);
        void Update(Department department);
        void Delete(Guid id);
        bool Any(Guid id);


    }
}
