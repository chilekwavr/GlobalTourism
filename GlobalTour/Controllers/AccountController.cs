using GlobalTour.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldTour.Infrastructure;

namespace GlobalTour.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<StoreUser> _signInManager;
        private readonly UserManager<StoreUser> _userManager;
        private readonly IConfiguration _config;

        public AccountController(ILogger<AccountController> logger,
          SignInManager<StoreUser> signInManager,
          UserManager<StoreUser> userManager,
          IConfiguration config)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username,
                  model.Password,
                  model.RememberMe,
                  false);

                if (result.Succeeded)
                {
                    //if (Request.Query.Keys.Contains("ReturnUrl"))
                    //{
                    //    return Redirect(Request.Query["ReturnUrl"].First());
                    //}
                    //else
                    //{
                        RedirectToAction("Index", "Home");
                    //}
                }
            }

            ModelState.AddModelError("", "Failed to login");

            return View();
        }
    }
}
