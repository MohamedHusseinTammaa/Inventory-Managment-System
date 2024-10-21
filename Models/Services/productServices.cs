
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

        public void createProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _context.products.Add(product);
            _context.SaveChanges();
        }

        public void deleteProduct(int id)
        {
            var product = _context.products.Find(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }

            _context.products.Remove(product);
            _context.SaveChanges();
        }

        public List<Product> getAllProducts()
        {
            return _context.products.ToList();
        }
    }
}
