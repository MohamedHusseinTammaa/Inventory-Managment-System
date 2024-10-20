using System.ComponentModel.DataAnnotations;

namespace Inventory_Managment_System.Models.Classes
{
    public class Purchase
    {
        [Key]
        public int id { get; set; }
        public double totalCost { get; set; }
        public DateTime purchaseDate { get; set; }
        public string paymentMethod {get; set ;}
        public DateTime deliveryDate {get ; set;} // when its delivered
        public DateTime createdAt {get ; set;}
        public DateTime updatedAt {get ; set;}

         // Foreign key
        public int supplierId { get; set; }
        public Supplier supplier { get; set; }
        
        // Navigation property
        public ICollection<PurchaseDetails> PurchaseDetails { get; set; }
    }
}
