using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specification;
using GlobalTour.Models;
using GlobalTour.Services;
using GlobalTour.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IDevelopersService _devService;

        public HomeController(ILogger<HomeController> logger, IGenericRepository<Developer> repo, IDevelopersService devService)
        {
            _logger = logger;
            _repo = repo;
            _devService = devService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var developer = await _repo.GetByIdAsync(1);
            var developers = await _repo.GetAllAsync();
            var specification = new DeveloperWithAddressSpecification(1);
            //var specification = new DeveloperByIncomeSpecification();
            var developers2 = _repo.FindWithSpecificationPattern(specification);


            var dev = developers2.FirstOrDefault();

            var wHistory = dev.WorkHistories.ToList();
            var wH = wHistory[0];

            var devServiceResult = _devService.GetDeveloperWithAddressById(1);

            //TODO: get ID from email using filters
            var result = PopulateDeveloperVM(1);

            var envURL = Environment.GetEnvironmentVariable("VaultUri");
            if(envURL==null)
            {
                envURL = "vault not found";
            }
            var vm = new StartUpVM
            {
                ConnectionString = ConnectionStringFactory.GetConnectionString(),
                VaultURL = envURL,
                DeveloperName = result.Developer.Name,
                WHName = result.WorkHistories[0].Name
            };

            return View(vm);
        }

        private StartUpVM PopulateDeveloperVM(int Id)
        {
            var developers = _devService.GetDeveloperWithAddressById(Id);
            var vm = new StartUpVM();
            vm.Developer = developers[0];
            vm.WorkHistories = developers[0].WorkHistories.ToList();
            return vm;
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
