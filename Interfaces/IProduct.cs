using Inventory_Managment_System.Models.Classes;
using System.Runtime.InteropServices;

namespace Inventory_Managment_System.Interfaces
{
    public interface IProduct
    {

        public Task<IEnumerable<Product>> getAllProducts();
        public void deleteProduct(int id);
        public  Product getProductById(int id);
        public void UpdateProduct(Product product);
        public Task<Product> createProduct(Product product);
        public IEnumerable<Product> getProductsByName(string name);
        public Task<int> CountProducts();
    }
}
