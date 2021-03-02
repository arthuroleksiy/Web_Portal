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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext db;
        public CustomerRepository(ApplicationDbContext dbContext)
        {
            this.db = dbContext;
        }
        public async Task AddAsync(Customer entity)
        {

            await Task.Run(() => db.Customers.Add(entity));
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Customer> FindAll()
        {
            return db.Customers;
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
