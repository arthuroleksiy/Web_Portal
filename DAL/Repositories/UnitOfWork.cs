using DAL.Context;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;
        private ICategoryRepository categoryRepository;

        private ICustomerRepository customerRepository;

        private IOrderRepository orderRepository;

        private IProductOrderRepository productOrderRepository;

        private IProductRepository productRepository;

        private IStatusRepository statusRepository;

        private IProductSizeRepository productSizeRepository;
        public UnitOfWork(ApplicationDbContext db)
        {
            this.db = db;
        }
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);

                return categoryRepository;
            }
        }


        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (customerRepository == null)
                    customerRepository = new CustomerRepository(db);

                return customerRepository;
            }
        }


        public IOrderRepository OrderRepository
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);

                return orderRepository;
            }
        }

        public IProductOrderRepository ProductOrderRepository
        {
            get
            {
                if (productOrderRepository == null)
                    productOrderRepository = new ProductOrderRepository(db);

                return productOrderRepository;
            }
        }

        public IStatusRepository StatusRepository
        {
            get
            {
                if (statusRepository == null)
                    statusRepository = new StatusRepository(db);

                return statusRepository;
            }
        }

        public IProductSizeRepository ProductSizeRepository
        {
            get
            {
                if (productSizeRepository == null)
                    productSizeRepository = new ProductSizeRepository(db);

                return productSizeRepository;
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);

                return productRepository;
            }
        }

        public Task<int> SaveAsync()
        {

            return Task.Run(() => db.SaveChangesAsync());
        }
    }
}
