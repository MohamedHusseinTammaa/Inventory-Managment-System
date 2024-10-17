using System.Runtime.InteropServices;

namespace Inventory_Managment_System.Models.Classes
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int priceFraction { get; set; }
        public int stockQuantity { get; set; }
        public int minimunStock { get; set; }
        public int categoryId { get; set; }
        public int supplierId { get; set; }
    }
}
