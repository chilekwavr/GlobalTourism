using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _config;

        public ApplicationDbContext(IConfiguration config) 
        {
            _config = config;
        }

        public DbSet<Developer> Developers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<PersonName> PersonNames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:GlobalTourismConnectionStr"]); //can use _config.ConnectionStrng() but assumes you ConnectionString in config file
        }

        //public DbSet<Address> Addresses { get; set; }
    }
}