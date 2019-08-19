using BusinessHR.Data;
using BusinessHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly IRepository<Permission> permissionRepository;
        private readonly IUnitOfWork unitOfWork;
        public PermissionService(IRepository<Permission> permissionRepository, IUnitOfWork unitOfWork)
        {
            this.permissionRepository = permissionRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(Guid id)
        {
            return permissionRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var permission = permissionRepository.Get(id);
            if (permission != null)
            {
                permissionRepository.Delete(permission);
                unitOfWork.SaveChanges();
            }
        }

        public Permission Get(Guid id)
        {
            return permissionRepository.Get(id);
        }

        public IEnumerable<Permission> GetAll()
        {
            return permissionRepository.GetAll();
        }

        public void Insert(Permission permission)
        {
            permissionRepository.Insert(permission);
            unitOfWork.SaveChanges();
        }

        public void Update(Permission permission)
        {
            permissionRepository.Update(permission);
            unitOfWork.SaveChanges();
        }
    }
    public interface IPermissionService
    {
        IEnumerable<Permission> GetAll();
        Permission Get(Guid id);
        void Insert(Permission permission);
        void Update(Permission permission);
        void Delete(Guid id);
        bool Any(Guid id);


    }
}
