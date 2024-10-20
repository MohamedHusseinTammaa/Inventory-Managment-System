using System.ComponentModel.DataAnnotations;

namespace Inventory_Managment_System.Models.Classes
{
    public class Order
    {
        [Key]
        public int id { get; set; }
        public DateTime orderDate { get; set; }
        public double totalAmount { get; set; }
    }
}
