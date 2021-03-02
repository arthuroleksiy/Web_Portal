using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public decimal TotalOrderCost { get; set; }
        public int OrderedCount { get; set; }
        public virtual List<OrderDTO> Orders { get; set; }
    }
}
