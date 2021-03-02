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
    public class CategoryService : ICategoryService
    {

        private IUnitOfWork UnitOfWork { get; set; }
        private IMapper mapper { get; set; }

        public CategoryService(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            this.UnitOfWork = UnitOfWork;
            this.mapper = mapper;
        }

        public Task AddAsync(CategoryDTO model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int modelId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            var categories = this.UnitOfWork.CategoryRepository.FindAll();
            return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);
        }

        public Task<CategoryDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CategoryDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
