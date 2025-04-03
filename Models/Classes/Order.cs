using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Inventory_Managment_System.Models.Classes
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }

        // Foreign key
        public int CustomerId { get; set; }

        // Navigation property
        [AllowNull]
        public Customer Customer { get; set; }

        // Navigation property for related order details
        public List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

        // Method to calculate the total amount from order details
        public void CalculateTotalAmount()
        {
            if (OrderDetails != null && OrderDetails.Count > 0)
            {
                TotalAmount = OrderDetails.Sum(od => (double)od.Price * od.Quantity);
            }
        }
    }

}