using BusinessHR.Data;
using BusinessHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Service
{
    public class PermissionTypeService : IPermissionTypeService
    {
        private readonly IRepository<PermissionType> permissionTypeRepository;
        private readonly IUnitOfWork unitOfWork;
        public PermissionTypeService(IRepository<PermissionType> permissionTypeRepository, IUnitOfWork unitOfWork)
        {
            this.permissionTypeRepository = permissionTypeRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(Guid id)
        {
            return permissionTypeRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var permissionType = permissionTypeRepository.Get(id);
            if (permissionType != null)
            {
                permissionTypeRepository.Delete(permissionType);
                unitOfWork.SaveChanges();
            }
        }

        public PermissionType Get(Guid id)
        {
            return permissionTypeRepository.Get(id);
        }

        public IEnumerable<PermissionType> GetAll()
        {
            return permissionTypeRepository.GetAll();
        }

        public void Insert(PermissionType permissionType)
        {
            permissionTypeRepository.Insert(permissionType);
            unitOfWork.SaveChanges();
        }

        public void Update(PermissionType permissionType)
        {
            permissionTypeRepository.Update(permissionType);
            unitOfWork.SaveChanges();
        }
    }

    public interface IPermissionTypeService
    {
        IEnumerable<PermissionType> GetAll();
        PermissionType Get(Guid id);
        void Insert(PermissionType permissionType);
        void Update(PermissionType permissionType);
        void Delete(Guid id);
        bool Any(Guid id);


    }
}

