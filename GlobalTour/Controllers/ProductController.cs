using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;
using GlobalTour.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTour.Controllers
{
    public class ProductController :BaseController
    {
        private readonly IGenericRepository<Product> _productsRepo;

        public ProductController(IGenericRepository<Product> productsRepo, IMapper mapper):base(mapper)
        {
            _productsRepo = productsRepo;

        }
        // GET: ProductController
        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DisplayProducts()
        {
            var model = await _productsRepo.GetAllAsync();
            return View(model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _productsRepo.GetByIdAsync(id);
            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ProductViewModel vm)
        {
            

            try
            {
                vm.ProductId = id;
               var result = _mapper.Map<Product>(vm);
                var model = _productsRepo.FindBy(a => a.Id == id)
                    .Include(a=>a.OrderDetails)
                    .Include(a => a.Suppliers)
                    .Include(a => a.Categories)
                    .FirstOrDefault();
                model.ProductName = vm.ProductName;
                model.UnitPrice = vm.UnitPrice;
                _productsRepo.Edit(model);
                _productsRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _productsRepo.GetByIdAsync(id);
            return View(model);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductViewModel vm)
        {
            try
            {
                vm.ProductId = id;
                var result = _mapper.Map<Product>(vm);
                var model = _productsRepo.FindBy(a => a.Id == id)
                    .Include(a => a.OrderDetails)
                    .FirstOrDefault();
                _productsRepo.Delete(model);
                _productsRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
