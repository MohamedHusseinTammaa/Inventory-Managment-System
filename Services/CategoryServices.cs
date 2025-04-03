using Inventory_Managment_System.Data;
using Inventory_Managment_System.Interfaces;
using Inventory_Managment_System.Models.Classes;
using Inventory_Managment_System.UnitOfWork;

namespace Inventory_Managment_System.Models.Services
{
    public class CategoryServices : ICategory
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Category>> getAllCategories()
        {
            return await _unitOfWork.Repository<Category>().getAllAsync();
        }
        public async Task<Category> createCategory(Category category)
        {
           if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            _unitOfWork.Repository<Category>().add(category);
            await _unitOfWork.CompleteAsync();
            return category;
        }
        public async Task<Category> updateCategory(Category category)
        {
            var EntityID = typeof(Category).GetProperty("id");
            int id = (int)EntityID.GetValue(category);
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            _unitOfWork.Repository<Category>().update(category,id);
            await _unitOfWork.CompleteAsync();
            return category;
        }
        public void deleteCategory(int id)
        {
            _unitOfWork.Repository<Category>().delete(id);
            _unitOfWork.Complete();
        }
        public async Task<int> countCategories()
        {
            return await _unitOfWork.Repository<Category>().countAllAsync();
        }
    }
}
