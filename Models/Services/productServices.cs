
using Inventory_Managment_System.Data;
using Inventory_Managment_System.Interfaces;
using Inventory_Managment_System.Models.Classes;
using System.Linq;

namespace Inventory_Managment_System.Models.Services
{
    public class ProductServices : IProduct
    {
        private readonly InventoryDbContext _context;
        
        public ProductServices(InventoryDbContext context) 
        {
            _context = context;
        }

        public void CreateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
    }
}
