using Inventory_Managment_System.Models.Classes;
using System.Runtime.InteropServices;

namespace Inventory_Managment_System.Interfaces
{
    public interface IProduct
    {
        public List<Product> getAllProducts();
        public void deleteProduct(int id);
<<<<<<< HEAD
        public void createProduct();
        public void UpdateProduct();
=======
        public void createProduct(Product product);
>>>>>>> ae58db61dad07e1b33928912ba9b33a01cadbe5f
    }
}
