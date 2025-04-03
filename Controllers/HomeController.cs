using Inventory_Managment_System.Interfaces;
using Inventory_Managment_System.Models;
using Inventory_Managment_System.Models.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Inventory_Managment_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProduct _productService;
        private readonly ISupplier _supplierService;
        private readonly IOrder _OrderService;

        public HomeController(IProduct productService, ISupplier supplierService, IOrder OrderService)
        {
            _productService = productService;
            _supplierService = supplierService;
            _OrderService = OrderService;
        }

        public IActionResult Index()
        {
            ViewBag.TotalProducts = _productService.CountProducts().Result;
            ViewBag.TotalSuppliers = _supplierService.CountAllSuppliers().Result;
            ViewBag.TotalOrders = _OrderService.CountAllOrders().Result;

            return View();
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
