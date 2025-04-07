using Inventory_Managment_System.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Managment_System.Models.Classes
{
    public class Product
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(25)]
        [MinLength(3)]
        public string name { get; set; }

        [MaxLength(300)]
        public string description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0, 999999.99, ErrorMessage = "Price must be between 0 and 999999.99")]
        public double price { get; set; }

        [Required]
        public int stockQuantity { get; set; }

        [Required]
        public int minimumStockLevel { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime createdAt { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public bool isDeleted { get; set; } = false;

        // Foreign keys
        [Required]
        [ForeignKey(nameof(category))]
        public int categoryId { get; set; }
        public Category category { get; set; }

        [Required]
        [ForeignKey(nameof(brand))]
        public int brandId { get; set; }
        public Brand brand { get; set; }

        [Required]
        [ForeignKey(nameof(supplier))]
        public int supplierId { get; set; }
        public Supplier supplier { get; set; }
    }
}
