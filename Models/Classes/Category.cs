using Inventory_Managment_System.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Managment_System.Models.Classes
{
    public class Category : ISharedProperties
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int parentCategory {get ; set ;}
        public DateTime createdAt {get ; set ;}
        public DateTime updatedAt {get ; set ;}
        // Navigation property
        public ICollection<Product> Products { get; set; }
    }
}
