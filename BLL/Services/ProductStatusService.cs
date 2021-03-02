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
    public class ProductStatusService : IProductStatusService
    {
        private IUnitOfWork UnitOfWork { get; set; }
        private IMapper mapper { get; set; }

        public ProductStatusService(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            this.UnitOfWork = UnitOfWork;
            this.mapper = mapper;
        }

        public Task AddAsync(ProductStatusDTO model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int modelId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductStatusDTO> GetAll()
        {
            var statuses = this.UnitOfWork.StatusRepository.FindAll();
            return mapper.Map<IEnumerable<Status>, IEnumerable<ProductStatusDTO>>(statuses);
        }

        public Task<ProductStatusDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProductStatusDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
