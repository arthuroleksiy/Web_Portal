using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class ProductOrder: BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int Quantity { get; set; }
    }
}
