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
    public class ProductSizeRepository : IProductSizeRepository
    {
        private readonly ApplicationDbContext db;
        public ProductSizeRepository(ApplicationDbContext dbContext)
        {
            this.db = dbContext;
        }
        public Task AddAsync(ProductSize entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductSize entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductSize> FindAll()
        {
            return db.ProductSizes;
        }

        public Task<ProductSize> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductSize entity)
        {
            throw new NotImplementedException();
        }
    }
}
