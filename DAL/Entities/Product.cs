using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Product: BaseEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public int ProductSizeId { get; set; }
        public virtual ProductSize ProductSize { get; set; }
        public virtual ICollection<ProductOrder> Orders { get; set; }
    }
}
