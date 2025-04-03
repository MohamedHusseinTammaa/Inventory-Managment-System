using Inventory_Managment_System.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Managment_System.Models.Classes
{
    public class Customer 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public string ContactInfo { get; set; } // Multivalue attribute
        public string Address { get; set; } // Composite attribute

        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime DeliveryDate { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation property
        public ICollection<Order> orders { get; set; }
    }

}
