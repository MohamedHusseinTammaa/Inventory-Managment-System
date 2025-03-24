using Inventory_Managment_System.Data;
using Inventory_Managment_System.Interfaces;
using Inventory_Managment_System.Models.Classes;
using Inventory_Managment_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Inventory_Managment_System.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _productService;
        private readonly ICategory _categoryService;
        private readonly IBrand _brandService;
        private readonly ISupplier _supplierService;
        private readonly Iorder _order;

        public ProductController(IProduct productService, ICategory categoryService, IBrand brandService,ISupplier supplierService, Iorder order)
        {
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
            _supplierService = supplierService;
            _order = order;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Search(string searchName)
        {
            searchName =searchName.Trim();
            if (string.IsNullOrWhiteSpace(searchName))
            {
                return RedirectToAction(nameof(getAllProduts));
            }

            var products = _productService.getProductsByName(searchName);
            ViewData["SearchTerm"] = searchName;
            return View("ProductSearchResultsView", products);
        }
        [HttpPost]
        public IActionResult deleteProduct(Product product)
        {
            _productService.deleteProduct(product.id);
            return RedirectToAction("Details",new { id =product.id});
        }
        [HttpGet]
        public IActionResult deleteProduct(int id)
        {
            var product=_productService.getProductById(id);
            return View(product);
        }

        public async Task <IActionResult> getAllProduts()
        {

            IEnumerable<Product> products = await _productService.getAllProducts();
            return View(products);
        }
        [HttpGet]
        public IActionResult createProduct()
        {
            ViewData["allsups"] = new SelectList(_supplierService.getAllSuppliers(), "id", "name");
            ViewData["allcats"] = new SelectList(_categoryService.getAllCategories(), "id", "name");
            ViewData["allbrands"] = new SelectList(_brandService.getAllBrands(), "id", "name");
            return View();
        }

        [HttpPost]
        public IActionResult createProduct(Product productt)
        {               
                _productService.createProduct(productt); 
                return RedirectToAction("getAllProduts"); 
        }
        public IActionResult Details(int id)
        {
            Product product = _productService.getProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View("ProductDetails", product);
        }
        [HttpGet]
		public IActionResult UpdateProduct(int id)
		{
			Product product = _productService.getProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            // Populate dropdown lists with current selections
            ViewData["allsups"] = new SelectList(_supplierService.getAllSuppliers(), "id", "name", product.supplierId);
			ViewData["allcats"] = new SelectList(_categoryService.getAllCategories(), "id", "name", product.categoryId);
			ViewData["allbrands"] = new SelectList(_brandService.getAllBrands(), "id", "name", product.brandId);

			return View(product);
		}

		[HttpPost]
		public IActionResult UpdateProduct(int id, Product product)
		{
            if (id != product.id)
            {
                return NotFound();
            }
            try
			{
				_productService.UpdateProduct(product);
				return RedirectToAction(nameof(getAllProduts));
			}
			catch
			{
				// If there's an error, reload the dropdown lists
				ViewData["allsups"] = new SelectList(_supplierService.getAllSuppliers(), "id", "name", product.supplierId);
				ViewData["allcats"] = new SelectList(_categoryService.getAllCategories(), "id", "name", product.categoryId);
				ViewData["allbrands"] = new SelectList(_brandService.getAllBrands(), "id", "name", product.brandId);
				return View(product);
			}

			//ViewData["allsups"] = new SelectList(_supplierService.getAllSuppliers(), "id", "name", product.supplierId);
			//ViewData["allcats"] = new SelectList(_categoryService.getAllCategories(), "id", "name", product.categoryId);
			//ViewData["allbrands"] = new SelectList(_brandService.getAllBrands(), "id", "name", product.brandId);
			//return View("UpdateProductView", product);
		}
	}


}

