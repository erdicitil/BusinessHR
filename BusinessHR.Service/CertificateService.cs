using BusinessHR.Data;
using BusinessHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Service
{
    public class CertificateService : ICertificateService
    {
        private readonly IRepository<Certificate> certificateRepository;
        private readonly IUnitOfWork unitOfWork;
        public CertificateService(IRepository<Certificate> certificateRepository, IUnitOfWork unitOfWork)
        {
            this.certificateRepository = certificateRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(Guid id)
        {
            return certificateRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var certificate = certificateRepository.Get(id);
            if (certificate != null)
            {
                certificateRepository.Delete(certificate);
                unitOfWork.SaveChanges();
            }
        }

        public Certificate Get(Guid id)
        {
            return certificateRepository.Get(id);
        }

        public IEnumerable<Certificate> GetAll()
        {
            return certificateRepository.GetAll();
        }

        public void Insert(Certificate certificate)
        {
            certificateRepository.Insert(certificate);
            unitOfWork.SaveChanges();
        }

        public void Update(Certificate certificate)
        {
            certificateRepository.Update(certificate);
            unitOfWork.SaveChanges();
        }
    }

    public interface ICertificateService
    {
        IEnumerable<Certificate> GetAll();
        Certificate Get(Guid id);
        void Insert(Certificate certificate);
        void Update(Certificate certificate);
        void Delete(Guid id);
        bool Any(Guid id);


    }
}

