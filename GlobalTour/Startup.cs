using GlobalTour.Services.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace GlobalTour
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity();
            services.AddAuthentication();
            services.AddDbContext(Configuration); 
            services.AddScopedServices();
            services.AddTransientServices();
            services.AddControllersWithViews();

            // services.AddIdentity<ApplicationDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:GlobalTourismConnectionStr"]));

            //services.AddIdentity();
            //<StoreUser, IdentityRole>(cfg =>
            //{
            //    cfg.User.RequireUniqueEmail = true;
            //})
            //.AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddAuthentication();
            //.AddCookie()
            //.AddJwtBearer(cfg =>
            //{
            //    cfg.TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidIssuer = Configuration["Tokens:Issuer"],
            //        ValidAudience = Configuration["Tokens:Audience"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
            //    };
            //});

            //services.AddDbContext<ApplicationDbContext>();
            //services.AddDbContext(Configuration); //<ApplicationDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:GlobalTourismConnectionStr"]));
            //services.AddScopedServices();
            //services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            //services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            //services.AddScoped<IDevelopersService, DevelopersService>();
            //services.AddTransient<SeedData>();
            //services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogInformation("In the configure method");

            var connectionStr = Configuration["ConnectionStrings:GlobalTourismConnectionStr"];

            if (connectionStr != null)
            {
                ConnectionStringFactory conFactory = new ConnectionStringFactory(connectionStr);
                logger.LogInformation("connection string: {constr}", connectionStr);
            }
            else
            {
                connectionStr = "connection string not found startup";
                ConnectionStringFactory conFactory = new ConnectionStringFactory(connectionStr);
                logger.LogInformation("connection string {constr}", connectionStr);

            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
