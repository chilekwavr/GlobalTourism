using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTour.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        [Display(Name = "Product name")]
        public string ProductName { get; set; }

        [Display(Name ="Unit price")]
        public decimal UnitPrice { get; set; }

    }
}
