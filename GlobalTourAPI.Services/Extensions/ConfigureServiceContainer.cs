using ApplicationCore.Interfaces;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using System;
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

        public static void AddSwaggerOpenAPI(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(setupAction =>
            {

                setupAction.SwaggerDoc(
                    "OpenAPISpecification",
                    new OpenApiInfo()
                    {
                        Title = "Onion Architecture WebAPI",
                        Version = "1",
                        Description = "Through this API you can access customer details",
                        Contact = new OpenApiContact()
                        {
                            Email = "amit.naik8103@gmail.com",
                            Name = "Amit Naik",
                            Url = new Uri("https://amitpnk.github.io/")
                        },
                        License = new OpenApiLicense()
                        {
                            Name = "MIT License",
                            Url = new Uri("https://opensource.org/licenses/MIT")
                        }
                    });

                //setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Type = SecuritySchemeType.Http,
                //    Scheme = "bearer",
                //    BearerFormat = "JWT",
                //    Description = $"Input your Bearer token in this format - Bearer token to access this API",
                //});
                //setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "Bearer",
                //            },
                //        }, new List<string>()
                //    },
                //});
            });

        }

        public static void AddHealthCheck(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>(name: "Application DB Context", failureStatus: HealthStatus.Degraded)
                .AddUrlGroup(new Uri("https://globaltourism.azurewebsites.net"), name: "My personal website", failureStatus: HealthStatus.Degraded)
                .AddSqlServer(configuration["ConnectionStrings:GlobalTourismConnectionStr"]);

            serviceCollection.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.AddHealthCheckEndpoint("Basic Health Check", $"/healthz");
            }).AddInMemoryStorage();
        }
    }
}
