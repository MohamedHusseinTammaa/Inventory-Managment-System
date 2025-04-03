using System.ComponentModel.DataAnnotations;

namespace Inventory_Managment_System.Models.Classes
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal FinalPrice { get; set; } // Total cost for this item

        // Foreign keys
        public int orderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public void CalculateFinalPrice()
        {
            FinalPrice = (Quantity * Price) - Discount + Tax;
        }
    }
}
