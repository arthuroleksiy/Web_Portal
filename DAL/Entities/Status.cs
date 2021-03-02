using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Status: BaseEntity
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }
}
