using Inventory_Managment_System.Models.Classes;
using System.Runtime.InteropServices;

namespace Inventory_Managment_System.Interfaces
{
    public interface IProduct
    {

        public List<Product> getAllProducts();
        public void deleteProduct(int id);
        public Product getProductById(int id);
        public void UpdateProduct(Product product);
        public void createProduct(Product product);
        public List<Product> getProductsByName(string name);
    }
}
