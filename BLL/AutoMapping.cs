using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class AutoMapping : Profile
    {
        public AutoMapping() {


            CreateMap<Order, OrderDTO>()
                .ForMember(o => o.OrderId, od => od.MapFrom(c => c.OrderId))
                .ForMember(o => o.StatusId, od => od.MapFrom(c => c.StatusId))
                .ForMember(o => o.Status, od => od.MapFrom(c => c.Status.StatusName))
                .ForMember(o => o.OrderDate, od => od.MapFrom(c => c.OrderDate))
                .ForMember(o => o.Comment, od => od.MapFrom(c => c.Comment))
                .ForMember(o => o.CustomerId, od => od.MapFrom(c => c.CustomerId))
                .ForMember(o => o.Customer, od => od.MapFrom(c => c.Customer.CustomerName))
                .ForMember(o => o.Products, od => od.MapFrom(c => c.Products))
                .ReverseMap();

            CreateMap<ProductOrderDTO, ProductOrder>()
                .ForMember(s => s.ProductId, sd => sd.MapFrom(c => c.ProductId))
                //.ForMember(s => s.Product, sd => sd.MapFrom(c => c.Product))
                .ForMember(s => s.Quantity, sd => sd.MapFrom(c => c.Quantity))
                .ReverseMap();

            CreateMap<Status, ProductStatusDTO>()
                .ForMember(s => s.StatusId, sd => sd.MapFrom(c => c.StatusId))
                .ForMember(s => s.StatusName, sd => sd.MapFrom(c => c.StatusName))
                .ReverseMap();

           /* CreateMap<Product, ProductDTO>()
                .ForMember(s => s.ProductId, sd => sd.MapFrom(c => c.ProductId))
                .ForMember(s => s.ProductName, sd => sd.MapFrom(c => c.ProductName))
                .ForMember(s => s.ProductSize, sd => sd.MapFrom(c => c.ProductSize))
                .ForMember(s => s.ProductSizeId, sd => sd.MapFrom(c => c.ProductSizeId))
                .ForMember(s => s.Price, sd => sd.MapFrom(c => c.Price))
                .ForMember(s => s.Description, s => s.MapFrom(c => c.Description))
                .ForMember(s => s.CreateDate, sd => sd.MapFrom(c => c.CreateDate))
                .ForMember(s => s.CategoryId, sd => sd.MapFrom(c => c.CategoryId))
                .ForMember(s => s.AvailableQuantity, s => s.MapFrom(c => c.AvailableQuantity))
                .ForMember(s => s.Category, s => s.MapFrom(c => c.Category))
                .ForMember(s => s.Orders, s =>s.MapFrom(c => c.Orders))
                .ReverseMap();*/
           CreateMap<Product, ProductDTO>()
                .ForMember(s => s.ProductId, sd => sd.MapFrom(c => c.ProductId))
                .ForMember(s => s.ProductName, sd => sd.MapFrom(c => c.ProductName))
                .ForMember(s => s.ProductSize, sd => sd.MapFrom(c => c.ProductSize.Size))
                .ForMember(s => s.ProductSizeId, sd => sd.MapFrom(c => c.ProductSizeId))
                .ForMember(s => s.Price, sd => sd.MapFrom(c => c.Price))
                .ForMember(s => s.Description, s => s.MapFrom(c => c.Description))
                .ForMember(s => s.CreateDate, sd => sd.MapFrom(c => c.CreateDate))
                .ForMember(s => s.CategoryId, sd => sd.MapFrom(c => c.CategoryId))
                .ForMember(s => s.AvailableQuantity, s => s.MapFrom(c => c.AvailableQuantity))
                .ForMember(s => s.Category, s => s.MapFrom(c => c.Category.CategoryName))
                .ReverseMap();
            //.ForMember(s => s.Orders, s => s.MapFrom(c => c.Orders))

            CreateMap<Category, CategoryDTO>()
                .ForMember(s => s.CategoryId, sd => sd.MapFrom(c => c.CategoryId))
                .ForMember(s => s.CategoryName, sd => sd.MapFrom(c => c.CategoryName))
                .ReverseMap();

            CreateMap<ProductSize, ProductSizeDTO>()
                .ForMember(s => s.ProductSizeId, sd => sd.MapFrom(c => c.ProductSizeId))
                .ForMember(s => s.Size, sd => sd.MapFrom(c => c.Size))
                .ReverseMap();

            CreateMap<Customer, CustomerDTO>()
                .ForMember(o => o.CreationDate, od => od.MapFrom(c => c.CreationDate))
                .ForMember(o => o.CustomerId, od => od.MapFrom(c => c.CustomerId))
                .ForMember(o => o.CustomerName, od => od.MapFrom(c => c.CustomerName))
                .ForMember(o => o.CustomerAddress, od => od.MapFrom(c => c.CustomerAddress))
                .ForMember(o => o.Orders, od => od.MapFrom(c => c.Orders))
                .ReverseMap();
        }
    }
}
