using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProductOrderRepository : IRepository<ProductOrder>
    {
        Task<List<ProductOrder>> GetAllAsync();

        Task<List<ProductOrder>> GetByProductIdAsync(int product);
        Task AddProductToOrderAsync(ProductOrder entity);
        
        Task UpdateAsync(ProductOrder entity);
    }
}
