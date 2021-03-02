using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Status> Status { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database = WebPortal;Integrated Security = True;MultipleActiveResultSets=true;")
                .UseLazyLoadingProxies();
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProductOrder>().HasKey(bc => new { bc.ProductId, bc.OrderId });

            modelBuilder.Entity<ProductOrder>()
                .HasOne(po => po.Order)
                .WithMany(o => o.Products).HasForeignKey(po => po.OrderId)
                .HasForeignKey(po => po.OrderId);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(po => po.Product)
                .WithMany(p => p.Orders).HasForeignKey(po => po.ProductId)
                .HasForeignKey(po => po.ProductId);

            modelBuilder.Entity<Product>()
                .HasOne(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, CreationDate = new DateTime(2019, 8, 7), CustomerName = "Arthur Oleksiy", CustomerAddress = "Kyiv, Myhailivska 15", },
                new Customer { CustomerId = 2, CreationDate = new DateTime(2019, 9, 8), CustomerName = "Bohdan Oliynik", CustomerAddress = "Kyiv, Tulchinska 8", }
            );

            modelBuilder.Entity<Category>().HasData(
                 new Category { CategoryId = 1, CategoryName = "Foods" },
                 new Category { CategoryId = 2, CategoryName = "Household goods" }
                 );

            modelBuilder.Entity<Status>().HasData(
                 new Status { StatusId = 1, StatusName = "New" },
                 new Status { StatusId = 2, StatusName = "Paid" },
                 new Status { StatusId = 3, StatusName = "Shipped" },
                 new Status { StatusId = 4, StatusName = "Delivered" },
                 new Status { StatusId = 5, StatusName = "Closed" }
                 );

            modelBuilder.Entity<ProductSize>().HasData(
                 new ProductSize { ProductSizeId = 1, Size = "Small" },
                 new ProductSize {  ProductSizeId =2, Size = "Medium" },
                 new ProductSize { ProductSizeId = 3, Size = "Large" }
                 );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId=1, ProductName = "Pizza", CategoryId = 1, ProductSizeId = 1, AvailableQuantity = 50, CreateDate = new DateTime(2019, 8, 7), Price = 50, Description = "What do you smell"},
                new Product { ProductId = 2, ProductName = "Chocolate", CategoryId = 1, ProductSizeId = 1, AvailableQuantity = 100, CreateDate = new DateTime(2019, 8, 10), Price = 20, Description = "Manflesh" }
                );

            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, StatusId =1, Comment = "BC", OrderDate = new DateTime(2020,10,10), CustomerId = 1  },
                new Order { OrderId = 2, StatusId = 3, Comment = "BC", OrderDate = new DateTime(2020, 11, 10), CustomerId = 2 }
                );

            modelBuilder.Entity<ProductOrder>().HasData(
                new ProductOrder { OrderId =1 , ProductId=1},
                new ProductOrder { OrderId = 1, ProductId = 2},
                new ProductOrder { OrderId = 2, ProductId = 1 });

            base.OnModelCreating(modelBuilder);

        }
    }
}

