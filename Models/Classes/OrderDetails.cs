using System.ComponentModel.DataAnnotations;

namespace Inventory_Managment_System.Models.Classes
{
    public class OrderDetails
    {
        [Key]
        public int id { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
        public decimal discount {get ; set ;}
        public decimal tax {get ; set ;}
        public decimal finalPrice {get ; set ;}
    }
}
