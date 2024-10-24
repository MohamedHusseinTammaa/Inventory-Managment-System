using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Inventory_Managment_System.Models.Classes
{
    public class order
    {
        [Key]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }

        // Foreign key
        public int CustomerId { get; set; }

        // Navigation property
        public Customer Customer { get; set; }

        // Navigation property for related order details
        public ICollection<orderDetails> orderDetails { get; set; } 

        // Method to calculate the total amount from order details
        
    }
}
