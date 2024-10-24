using System.ComponentModel.DataAnnotations;

namespace Inventory_Managment_System.Models.Classes
{
    public class orderDetails
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }
        public double Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal FinalPrice { get; set; } // Total cost for this item

        // Foreign keys
        public int orderId { get; set; }
        public order order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        // Method to calculate final price
        //public void CalculateFinalPrice()
        //{
        //    FinalPrice = (Quantity * Price) - Discount + Tax;
        //}
    }
}
