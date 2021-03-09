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

        public async Task UpdateAsync(OrderDTO model)
        {
            var order = mapper.Map<OrderDTO, Order>(model);
            order.Products.Select(i => i.OrderId = model.OrderId).First();
            await UnitOfWork.OrderRepository.UpdateAsync(new Order
            {
                OrderId = order.OrderId,
                Comment = order.Comment,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                StatusId = order.StatusId,
                Products = null
            });
            var productOrders = await UnitOfWork.ProductOrderRepository.GetAllAsync();
            var alreadyOrdered = productOrders.Where(i => i.OrderId == model.OrderId).Select(j => j).ToList();
            foreach(var i in alreadyOrdered)
            {
                if(!productOrders.Select(j => j.ProductId).Contains(i.ProductId))
                {
                    UnitOfWork.ProductOrderRepository.Delete(i);
                }
            }
            foreach (var i in order.Products)
            {
                foreach (var j in alreadyOrdered)
                {
                    if(i.ProductId != j.ProductId && i.OrderId != j.ProductId) {
                        await UnitOfWork.ProductOrderRepository.DeleteByIdAsync(i.ProductId, i.OrderId);
                }
                }
            }
            await UnitOfWork.SaveAsync();
        }

        public Task AddProductToOrderAsync(ProductDTO product, OrderDTO order)
        {
            throw new NotImplementedException();
        }
    }
}
