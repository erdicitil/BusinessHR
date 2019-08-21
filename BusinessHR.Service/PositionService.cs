using BusinessHR.Data;
using BusinessHR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Service
{
    public class PositionService : IPositionService
    {
        private readonly IRepository<Position> positionRepository;
        private readonly IUnitOfWork unitOfWork;
        public PositionService(IRepository<Position> positionRepository, IUnitOfWork unitOfWork)
        {
            this.positionRepository = positionRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(Guid id)
        {
            return positionRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var position = positionRepository.Get(id);
            if (position != null)
            {
                positionRepository.Delete(position);
                unitOfWork.SaveChanges();
            }
        }

        public Position Get(Guid id)
        {
            return positionRepository.Get(id);
        }

        public IEnumerable<Position> GetAll()
        {
            return positionRepository.GetAll();
        }

        public void Insert(Position position)
        {
            positionRepository.Insert(position);
            unitOfWork.SaveChanges();
        }

        public void Update(Position position)
        {
            positionRepository.Update(position);
            unitOfWork.SaveChanges();
        }
    }

    public interface IPositionService
    {
        IEnumerable<Position> GetAll();
        Position Get(Guid id);
        void Insert(Position position);
        void Update(Position position);
        void Delete(Guid id);
        bool Any(Guid id);


    }
}


