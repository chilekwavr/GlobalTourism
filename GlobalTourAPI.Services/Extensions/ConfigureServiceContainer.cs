using ApplicationCore.Interfaces;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WorldTour.Infrastructure;

namespace GlobalTourAPI.Services.Extensions
{
    public static class ConfigureServiceContainer
    {
        public static void AddController(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddControllers().AddNewtonsoftJson();
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
        }

        public static void AddTransientServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            //serviceCollection.AddTransient<SeedData>();
        }
    }
}
