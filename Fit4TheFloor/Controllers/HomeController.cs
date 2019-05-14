using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fit4TheFloor.Models;
using Fit4TheFloor.Models.Interfaces;
using Fit4TheFloor.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Fit4TheFloor.Controllers
{
    public class HomeController : Controller
    {
        private IAppUserManager _user;

        public HomeController(IAppUserManager user)
        {
            _user = user;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult About()
        {
            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Contact(ContactViewModel bag /*Email bag*/)
        {
            // build Email object from ContactViewModel
            // alternative: Ditch the 'ContactViewModel' and just build 'Email' object in Contact form
            return View();
        }

    }
}
