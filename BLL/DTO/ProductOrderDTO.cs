using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class ProductOrderDTO 
    {
        public int ProductId { get; set; }
        public virtual ProductDTO Product { get; set; }
        //public int OrderId { get; set; }
        //public virtual OrderDTO Order { get; set; }
        public int Quantity { get; set; }
    }
}
