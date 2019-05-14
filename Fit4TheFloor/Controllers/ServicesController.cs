using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fit4TheFloor.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Fit4TheFloor.Controllers
{
    public class ServicesController : Controller
    {
        private IBlogPostManager _post;

        public ServicesController(IBlogPostManager post)
        {
            _post = post;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Fitness()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Nutrition()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult LifeCoaching()
        {
            return View();
        }
    }
}
