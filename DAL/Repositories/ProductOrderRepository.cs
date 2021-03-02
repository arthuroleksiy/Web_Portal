using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProductOrderRepository : IProductOrderRepository
    {
        private readonly ApplicationDbContext db;
        public ProductOrderRepository(ApplicationDbContext dbContext)
        {
            this.db = dbContext;
        }
        public Task AddAsync(ProductOrder entity)
        {
            throw new NotImplementedException();
        }

        public async Task AddProductToOrderAsync(ProductOrder entity)
        {
            await db.ProductOrders.AddAsync(new ProductOrder { OrderId = entity.OrderId, ProductId = entity.ProductId, Quantity = entity.Quantity});
            await db.SaveChangesAsync();
        }

        public void Delete(ProductOrder entity)
        {
            db.ProductOrders.Remove(entity);
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductOrder> FindAll()
        {
            throw new NotImplementedException();
        }
        public async Task<List<ProductOrder>> GetAllAsync()
        {
            return await db.Set<ProductOrder>().ToListAsync();
        }

        public Task<ProductOrder> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductOrder>> GetByProductIdAsync(int product)
        {
            return await db.ProductOrders.Where(i => i.ProductId == product).ToListAsync();
        }

        public void Update(ProductOrder entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(ProductOrder entity)
        {
            db.Set<ProductOrder>().Update(entity);
            await db.SaveChangesAsync();
        }
    }
}
