using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Order: BaseEntity
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<ProductOrder> Products { get; set; }
        [Required]
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
        public DateTime OrderDate { get; set; }
        public string Comment { get; set; }
    }
}
