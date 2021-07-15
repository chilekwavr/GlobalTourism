using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorldTour.Infrastructure
{
    public interface IApplicationDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<PersonName> PersonNames { get; set; }

        Task<int> SaveChangesAsync();
    }
}
