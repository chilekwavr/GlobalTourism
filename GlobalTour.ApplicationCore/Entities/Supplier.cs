using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Supplier : BaseEntity
    {
        public string SupplierName { get; set; }
        public List<Product> Products { get; set; }
    }
}
