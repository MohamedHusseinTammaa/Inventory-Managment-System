using Inventory_Managment_System.Models.Classes;

namespace Inventory_Managment_System.Interfaces
{
    public interface ICategory
    {
		public Task<IEnumerable<Category>> getAllCategories();
        public Task<Category> createCategory(Category category);
        public Task<Category> updateCategory(Category category);
        public void deleteCategory(int id);
        public Task<int> countCategories();
    }
}
