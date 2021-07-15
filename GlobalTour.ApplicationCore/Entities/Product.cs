using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
        public Category Categories { get; set; }
        public Supplier Suppliers { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
    //public class Product : BaseEntity
    //  {
    //  public string Category { get; set; }
    //  public string Size { get; set; }
    //  public decimal Price { get; set; }
    //  public string Title { get; set; }
    //  public string ArtDescription { get; set; }
    //  public string ArtDating { get; set; }
    //  public string ArtId { get; set; }
    //  public string Artist { get; set; }
    //  public DateTime ArtistBirthDate { get; set; }
    //  public DateTime ArtistDeathDate { get; set; }
    //  public string ArtistNationality { get; set; }
    //}
}
