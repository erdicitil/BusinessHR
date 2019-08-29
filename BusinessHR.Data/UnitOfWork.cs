using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessHR.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;
        public UnitOfWork(ApplicationDbContext context)
        {
            this.db = context;
        }
        public void SaveChanges()
        {
           
                db.SaveChanges();
            
            
            
            
        }
    }

    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}

