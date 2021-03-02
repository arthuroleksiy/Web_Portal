using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrderService : ICrud<OrderDTO>
    {
        Task AddProductToOrderAsync(ProductDTO product, OrderDTO order);
    }
}
