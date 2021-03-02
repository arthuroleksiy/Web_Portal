using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork UnitOfWork { get; set; }
        private IMapper mapper { get; set; }

        public ProductService(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            this.UnitOfWork = UnitOfWork;
            this.mapper = mapper;
        }
        public async Task AddAsync(ProductDTO product)
        {
            //var model = mapper.Map<Product>(product);

            await UnitOfWork.ProductRepository.AddAsync(new Product { 
                AvailableQuantity = product.AvailableQuantity, 
                CategoryId = product.CategoryId, 
                CreateDate = product.CreateDate, 
                ProductSizeId = product.ProductSizeId, 
                ProductName = product.ProductName, 
                Description = product.Description,
                Price = product.Price });
            await UnitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int productId)
        {
            //var product = await UnitOfWork.ProductRepository.GetByIdAsync(productId);
            var productOrders = await UnitOfWork.ProductOrderRepository.GetByProductIdAsync(productId);
            foreach (var order in productOrders)
            {
                UnitOfWork.ProductOrderRepository.Delete(order);
            } 
            await UnitOfWork.ProductRepository.DeleteByIdAsync(productId);
            await UnitOfWork.SaveAsync();
            
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var allProducts = UnitOfWork.ProductRepository.FindAll();
            return mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(allProducts);
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var allProducts = await UnitOfWork.ProductRepository.GetByIdAsync(id);
            return mapper.Map<Product, ProductDTO>(allProducts);

        }

        public Task UpdateAsync(ProductDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
