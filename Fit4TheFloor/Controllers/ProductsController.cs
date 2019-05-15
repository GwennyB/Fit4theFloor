using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fit4TheFloor.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Fit4TheFloor.Controllers
{
    public class ProductsController : Controller
    {
        private IAppUserManager _user;
        private IProductManager _product;
        private IPurchaseManager _purchase;
        private IPrintManager _print;
        private ICartManager _cart;

        public ProductsController(IAppUserManager user, IProductManager product, IPurchaseManager purchase, IPrintManager print, ICartManager cart)
        {
            _user = user;
            _product = product;
            _purchase = purchase;
            _print = print;
            _cart = cart;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
