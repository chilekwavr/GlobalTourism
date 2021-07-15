using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Order : BaseEntity
    {
        public Customer Customers { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
    //public class Order : BaseEntity
    //  {
    //  public DateTime OrderDate { get; set; }
    //  public string OrderNumber { get; set; }
    //  public ICollection<OrderItem> Items { get; set; }
    //}
}
