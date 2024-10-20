using System.ComponentModel.DataAnnotations;

namespace Inventory_Managment_System.Models.Classes
{
    public class Supplier
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }//multivalue attribute
        public string address { get; set; }// composite attribute
        public string email { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

        // Navigation property
        public ICollection<Product> Products { get; set; }
    }
}
