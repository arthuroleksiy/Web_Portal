using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public  string CustomerName { get; set; }
        public  List<ProductOrderDTO> Products { get; set; }
        public int StatusId { get; set; }
        public  string StatusName { get; set; }
        public decimal TotalOrderCost { get; set; }
        public DateTime OrderDate { get; set; }
        public string Comment { get; set; }
    }
}
