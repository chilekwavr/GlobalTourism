using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTour.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        [Required]
        [Display(Name ="Customer name")]
        public string CustomerName { get; set; }
        [Required]
        [Display(Name = "Contact name")]
        public string ContactName { get; set; }
        [Required]
        [Display(Name = "Contact title")]
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}
