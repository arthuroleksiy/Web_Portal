using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public  string Category { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public int ProductSizeId { get; set; }
        public string ProductSize { get; set; }
        //public List<ProductOrder> Orders { get; set; }
    }
}
