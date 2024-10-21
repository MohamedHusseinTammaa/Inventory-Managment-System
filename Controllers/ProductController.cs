using Inventory_Managment_System.Data;
using Inventory_Managment_System.Interfaces;
using Inventory_Managment_System.Models.Classes;
using Inventory_Managment_System.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Managment_System.Controllers
{
    public class ProductController : Controller
    {
        public readonly IProduct product; 
        public readonly InventoryDbContext _context;
        public ProductController (IProduct productServices)
        {
            product = productServices;
        }
        public IActionResult Index()
        {
            List<Product> products = _context.products.ToList();
            return View("getAllProducts", products);
        }

    }
}
