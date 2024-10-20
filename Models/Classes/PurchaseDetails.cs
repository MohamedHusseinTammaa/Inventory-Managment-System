using System.ComponentModel.DataAnnotations;

namespace Inventory_Managment_System.Models.Classes
{
    public class PurchaseDetails
    {
        [Key]
        public int id {  get; set; }
        public int quantity { get; set; }
        public double costPrice { get; set; }
        public decimal discount{get ; set;}
        public decimal tax{get ; set;}
        public decimal finalPrice {get; set;} //The total cost for this item (Quantity × CostPrice - Discount + Tax)  
        
        // Foregin key
        
        public int productId { get; set; } 
        public Product product {get;set;}
    }
}
