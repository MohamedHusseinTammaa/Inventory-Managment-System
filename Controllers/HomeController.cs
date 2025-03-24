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
        private readonly Iorder _orderService;

        public HomeController(IProduct productService, ISupplier supplierService, Iorder orderService)
        {
            _productService = productService;
            _supplierService = supplierService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            ViewBag.TotalProducts =  _supplierService.getAllSuppliers().Count();
            ViewBag.TotalOrders = _orderService.GetAllOrders().Count();

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
