using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class ProductSize: BaseEntity
    {
        public int ProductSizeId { get; set; }
        [Required]
        public string Size { get; set; }
    }
}
