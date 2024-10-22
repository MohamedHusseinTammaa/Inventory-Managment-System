using Inventory_Managment_System.Data;
using Inventory_Managment_System.Interfaces;
using Inventory_Managment_System.Models.Classes;
using Inventory_Managment_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Inventory_Managment_System.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _productService;
        private readonly ICategory _categoryService;
        private readonly IBrand _brandService;
        private readonly ISupplier _supplierService;

        public ProductController(IProduct productService, ICategory categoryService, IBrand brandService,ISupplier supplierService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
            _supplierService = supplierService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult getAllProduts()
        {
            List<Product> products = _productService.getAllProducts();
            return View(products);
        }
        [HttpGet]
        public IActionResult createProduct()
        {
            ViewData["allsups"] = new SelectList(_supplierService.getAllSuppliers(), "id", "name");
            ViewData["allcats"] = new SelectList(_categoryService.getAllCategories(), "id", "name");
            ViewData["allbrands"] = new SelectList(_brandService.getAllBrands(), "id", "name");
            return View(); // Return the view with a form to create the product
        }

        [HttpPost]
        public IActionResult createProduct(Product productt)
        {
            //if (ModelState.IsValid)
            //{
                
                _productService.createProduct(productt); // Add the product
                return RedirectToAction("getAllProduts"); // Redirect to list of products
           // }

        }
    }


}

