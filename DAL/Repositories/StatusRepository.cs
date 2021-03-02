using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ApplicationDbContext db;
        public StatusRepository(ApplicationDbContext dbContext)
        {
            this.db = dbContext;
        }
        public Task AddAsync(Status entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Status entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Status> FindAll()
        {
            return db.Status;
        }

        public Task<Status> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Status entity)
        {
            throw new NotImplementedException();
        }
    }
}
