using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Customer: BaseEntity
    {
        public int CustomerId { get; set; }
        public DateTime CreationDate { get; set; }

        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerAddress { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
