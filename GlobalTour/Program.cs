using Azure.Identity;
using Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTour
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // if (args.Length == 1 && args[0].ToLower() == "/seed")
            //{
            RunSeed(host);
            //}
            //else
            // {
            host.Run();
            //}
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
                     Host.CreateDefaultBuilder(args)
                    .ConfigureAppConfiguration(SetUpConfiguration)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });

        private static void SetUpConfiguration(HostBuilderContext context, IConfigurationBuilder config)
        {
            var envVault = Environment.GetEnvironmentVariable("VaultUri");
            if (envVault != null)
            {
                var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
                config.AddAzureKeyVault(
                keyVaultEndpoint,
                new DefaultAzureCredential());
            }
            //config.SetBasePath(Directory.GetCurrentDirectory());
            //config.AddJsonFile("appSettings.json", optional: false, reloadOnChange: true);
            //config.AddEnvironmentVariables();
        }

        private static void RunSeed(IHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<SeedData>();
                seeder.Seed().Wait();
            }
        }
    }
}
