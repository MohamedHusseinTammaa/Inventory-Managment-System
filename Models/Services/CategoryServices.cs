using Inventory_Managment_System.Data;
using Inventory_Managment_System.Interfaces;
using Inventory_Managment_System.Models.Classes;

namespace Inventory_Managment_System.Models.Services
{
    public class CategoryServices : ICategory
    {
        private readonly InventoryDbContext _context;

        public CategoryServices(InventoryDbContext context)
        {
            _context = context;
        }
        public List<Category> getAllCategories()
        {
            var list = _context.categories.ToList();
            return list;
        }
    }
}
