using System.ComponentModel.DataAnnotations;

namespace Inventory_Managment_System.Models.Classes
{
    public class Customer
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string contactInfo { get; set; } // multivalue attribute
        public string address { get; set; } //composite attribute
        public string orderStatus{get ; set;}
        public string paymentStatus{get ; set;}
        public DateTime deliveryDate {get ; set ;}
        public DateTime createdAt {get ; set ;}
        public DateTime updatedAt {get ; set ;}
        // sales
        public ICollection<Order> Orders { get; set; }
    }
}
