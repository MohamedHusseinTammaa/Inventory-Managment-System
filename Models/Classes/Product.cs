using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Inventory_Managment_System.Models.Classes
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int stockQuantity { get; set; }
        public int minimumStockLevel { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Foreign keys
        public int categoryId { get; set; }
        public Category category { get; set; }
        
        public int brandId { get; set; }
        public Brand brand { get; set; }

        public int supplierId { get; set; }
        public Supplier supplier { get; set; }
    }
}
