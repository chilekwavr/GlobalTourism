using ApplicationCore.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using WorldTour.Infrastructure;

namespace GlobalTour.Services.Extensions
{
    public static class ConfigureServiceContainer
    {

        public static void AddAuthentication(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddAuthentication()
              .AddCookie()
              .AddJwtBearer(cfg =>
              {
                  cfg.TokenValidationParameters = new TokenValidationParameters()
                  {
                      ValidIssuer = configuration["Tokens:Issuer"],
                      ValidAudience = configuration["Tokens:Audience"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]))
                  };
              });
        }

        public static void AddIdentity(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddIdentity<StoreUser, IdentityRole>(cfg =>
             {
                 cfg.User.RequireUniqueEmail = true;
             })
            .AddEntityFrameworkStores<ApplicationDbContext>();
        }

        public static void AddDbContext(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration["ConnectionStrings:GlobalTourismConnectionStr"]));
        }

        public static void AddScopedServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            serviceCollection.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            serviceCollection.AddScoped<IDevelopersService, DevelopersService>();
        }

        public static void AddTransientServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<SeedData>();
        }
    }
}
