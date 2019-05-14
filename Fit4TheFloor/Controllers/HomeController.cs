using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fit4TheFloor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Fit4TheFloor.Controllers
{
    public class HomeController : Controller
    {
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
        public IActionResult Contact(Email message)
        {
            return View();
        }
    }
}
