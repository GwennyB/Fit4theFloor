using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fit4TheFloor.Models.Interfaces;
using Fit4TheFloor.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Fit4TheFloor.Controllers
{
    public class AccountController : Controller
    {
        private IAppUserManager _user;

        public AccountController(IAppUserManager userManager)
        {
            _user = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel bag)
        {
            if (ModelState.IsValid)
            {
                if (await _user.Register(bag))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
            return View(bag);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel bag)
        {
            if (ModelState.IsValid)
            {
                if (await _user.Login(bag))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Login failed. Please try again.");
            return View(bag);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _user.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
