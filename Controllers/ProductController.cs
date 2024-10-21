using Inventory_Managment_System.Interfaces;
using Inventory_Managment_System.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Managment_System.Controllers
{
    public class ProductController : Controller
    {
        public readonly IProduct product; 
        public ProductController (IProduct productServices)
        {
            product = productServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult getAllProduts() 
        { 
            var list = product.getAllProducts();
            return View(list);
        }

    }
}
