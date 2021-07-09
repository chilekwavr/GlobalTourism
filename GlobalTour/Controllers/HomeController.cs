using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specification;
using GlobalTour.Models;
using GlobalTour.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTour.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepository<Developer> _repo;

        public HomeController(ILogger<HomeController> logger, IGenericRepository<Developer> repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var developer = await _repo.GetByIdAsync(1);
            var developers = await _repo.GetAllAsync();
            var specification = new DeveloperWithAddressSpecification(1);
            //var specification = new DeveloperByIncomeSpecification();
            var developers2 = _repo.FindWithSpecificationPattern(specification);

            var dev = developers2.FirstOrDefault();

            var wHistory = dev.WorkHistories.ToList()[0];
            var envURL = Environment.GetEnvironmentVariable("VaultUri");
            if(envURL==null)
            {
                envURL = "vault not found";
            }
            var vm = new StartUpVM
            {
                ConnectionString = ConnectionStringFactory.GetConnectionString(),
                VaultURL = envURL,
                DeveloperName = dev.Name,
                WHName = wHistory.Name
            };

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
