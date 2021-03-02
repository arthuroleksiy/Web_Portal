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
    public class CustomerService : ICustomerService
    {
        private IUnitOfWork UnitOfWork { get; set; }
        private IMapper mapper { get; set; }
        private IOrderService orderService { get; set; }

        public CustomerService(IUnitOfWork UnitOfWork, IMapper mapper, IOrderService orderService)
        {
            this.UnitOfWork = UnitOfWork;
            this.mapper = mapper;
            this.orderService = orderService;
        }
        public async Task AddAsync(CustomerDTO model)
        {
            Customer customer = mapper.Map<Customer>(model);

            await UnitOfWork.CustomerRepository.AddAsync(customer);
            await UnitOfWork.SaveAsync();
        }

        public Task DeleteByIdAsync(int modelId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerDTO> GetAll()
        {
            var customerDTO = mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(UnitOfWork.CustomerRepository.FindAll());
            var orderDTO = orderService.GetAll();
            customerDTO.Select(i => i.OrderedCount = i.Orders.Where(j => j.CustomerId == i.CustomerId).Count()).ToList();
            customerDTO.Select(i => i.TotalOrderCost = orderDTO.Where(j => j.CustomerId == i.CustomerId).Sum(k => k.TotalOrderCost)).ToList();
            /*
            foreach(var i in customers)
            {
                foreach(var j in orders)
                {
                    if(j.CustomerId == i.CustomerId)
                    {
                        i.OrderedCount += 1;
                        i.TotalOrderCost += j.Products.Sum(x => x.Quantity * x.Product.Price);
                    }
                }
            }*/
            return customerDTO;
        }

        public Task<CustomerDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CustomerDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
