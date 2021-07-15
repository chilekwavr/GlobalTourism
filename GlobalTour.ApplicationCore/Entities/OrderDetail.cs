using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Order Orders { get; set; }
        public Product Product { get; set; }
    }
}
