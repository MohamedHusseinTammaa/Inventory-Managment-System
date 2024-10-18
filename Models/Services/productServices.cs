using Inventory_Managment_System.Data;
using Inventory_Managment_System.Interfaces;
using Inventory_Managment_System.Models.Classes;
using System.Linq;

namespace Inventory_Managment_System.Models.Services
{
    public class productServices : IProduct
    {
        private readonly InventoryDbContext _context;
        public productServices(InventoryDbContext context) 
        {
            _context= context;
        }

        public void createProduct()
        {
            throw new NotImplementedException();
        }

        public void deleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> getAllProducts()
        {
            List<Product> productsList = _context.products.ToList();
            
            return productsList;
        }
    }
}
