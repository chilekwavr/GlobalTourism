using ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using WorldTour.Infrastructure;

namespace Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<StoreUser>, IApplicationDbContext
    {
        private readonly IConfiguration _config;

        public ApplicationDbContext(IConfiguration config) 
        {
            _config = config;
        }

        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //{
        //    ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        //}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<PersonName> PersonNames { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<OrderDetail>().HasKey(o => new { o.OrderId, o.ProductId });
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //if (!optionsBuilder.IsConfigured)
            //{
                optionsBuilder.UseSqlServer(_config["ConnectionStrings:GlobalTourismConnectionStr"]); //can use _config.ConnectionStrng() but assumes you ConnectionString in config file
            //}
        }

        //used in API mediator pattern
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        //public DbSet<Address> Addresses { get; set; }
    }
}