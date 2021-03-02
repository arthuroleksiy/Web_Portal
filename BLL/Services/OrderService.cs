using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork UnitOfWork { get; set; }
        private IMapper mapper { get; set; }

        public OrderService(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            this.UnitOfWork = UnitOfWork;
            this.mapper = mapper;
        }

        public async Task AddAsync(OrderDTO model)
        {
            //var order = mapper.Map<OrderDTO, Order>(model);

            //var productOrder = mapper.Map<Order>order.
            var order = new Order { Comment = model.Comment, CustomerId = model.CustomerId, OrderDate = model.OrderDate, StatusId = model.StatusId };
            await UnitOfWork.OrderRepository.AddAsync(order);
            //await UnitOfWork.SaveAsync();
            var orderWithId = await UnitOfWork.OrderRepository.GetByObjectPropertiesAsync(order);
            if (model.Products != null) {
                foreach (var orderProduct in model.Products)
                {
                    await UnitOfWork.ProductOrderRepository.AddProductToOrderAsync(new ProductOrder { OrderId = orderWithId.OrderId, ProductId = orderProduct.ProductId, Quantity = orderProduct.Quantity });

                } 
            }

        }


        public Task DeleteByIdAsync(int modelId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            var result = UnitOfWork.OrderRepository.FindAll();
            var orderDTO = mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(result);
            orderDTO.Select(i => i.TotalOrderCost = i.Products.Sum(n => n.Quantity * n.Product.Price)).ToList();
            return orderDTO;
        }

        public Task<OrderDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(OrderDTO model)
        {
            throw new NotImplementedException();
        }

        public Task AddProductToOrderAsync(ProductDTO product, OrderDTO order)
        {
            throw new NotImplementedException();
        }
    }
}
