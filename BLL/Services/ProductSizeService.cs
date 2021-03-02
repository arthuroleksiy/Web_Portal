using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductSizeService : IProductSizeService
    {
        private IUnitOfWork UnitOfWork { get; set; }
        private IMapper mapper { get; set; }

        public ProductSizeService(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            this.UnitOfWork = UnitOfWork;
            this.mapper = mapper;
        }
        public Task AddAsync(ProductSizeDTO model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int modelId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductSizeDTO> GetAll()
        {
            var sies = this.UnitOfWork.ProductSizeRepository.FindAll();
            return mapper.Map<IEnumerable<ProductSize>, IEnumerable<ProductSizeDTO>>(sies);
        }

        public Task<ProductSizeDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProductSizeDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
