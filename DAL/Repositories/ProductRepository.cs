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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext db;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            this.db = dbContext;
        }
        public async Task AddAsync(Product entity)
        {

            //await Task.Run(() => db.Product.Add(new Product { ProductName = entity.ProductName, AvailableQuantity = entity.AvailableQuantity, CategoryId = entity.CategoryId, CreateDate = entity.CreateDate, Description = entity.Description, Price = entity.Price, ProductSizeId = entity.ProductSizeId  }));
            await Task.Run(() => db.Product.Add(entity));
            await db.SaveChangesAsync();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByIdAsync(int id)
        {
            await Task.Run(() =>
            {
                db.Product.Remove(db.Product.Find(id));
            });
        }

        public IQueryable<Product> FindAll()
        {
            return db.Product;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await db.Product.FindAsync(id);
            return product;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await db.Set<Product>().ToListAsync();
        }

        public void Update(Product entity)
        {
            db.Set<Product>().Update(entity);
        }

        public async Task UpdateAsync(Product entity)
        {
            db.Set<Product>().Update(entity);
            await db.SaveChangesAsync();

        }
    }
}
