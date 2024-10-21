using Inventory_Managment_System.Data;
using Inventory_Managment_System.Interfaces;
using Inventory_Managment_System.Models.Classes;

namespace Inventory_Managment_System.Models.Services
{
    public class BrandServices : IBrand
    {
        private readonly InventoryDbContext _context;

        public BrandServices(InventoryDbContext context)
        {
            _context = context;
        }
        public List<Brand> getAllBrands()
        {
            return _context.brands.ToList();
        }
    }
}
