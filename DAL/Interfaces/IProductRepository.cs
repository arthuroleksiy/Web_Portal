﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetAllAsync();
        Task UpdateAsync(Product entity);
    }
}
