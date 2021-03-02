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
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext db;
        public OrderRepository(ApplicationDbContext dbContext)
        {
            this.db = dbContext;
        }
        public async Task AddAsync(Order entity)
        {
            await db.Orders.AddAsync(new Order { Comment = entity.Comment, CustomerId = entity.CustomerId, OrderDate = entity.OrderDate, StatusId = entity.StatusId });
            await db.SaveChangesAsync();
        }

        public void Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> FindAll()
        {

            return db.Orders;
        }

        public Task<Order> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetByObjectPropertiesAsync(Order order)
        {
            var orderWithId = await Task.Run(() => db.Orders.Where(i => i.StatusId == order.StatusId && i.OrderDate == order.OrderDate && i.CustomerId == order.CustomerId && i.Comment == order.Comment && i.StatusId == order.StatusId).Select(j => j).FirstOrDefault());
            return orderWithId;
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
