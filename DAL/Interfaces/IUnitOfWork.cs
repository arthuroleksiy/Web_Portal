using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProductOrderRepository ProductOrderRepository { get; }
        IProductRepository ProductRepository { get; }
        IStatusRepository StatusRepository { get; }
        IProductSizeRepository ProductSizeRepository { get; }
        Task<int> SaveAsync();
    }
}
