using System.ComponentModel.DataAnnotations;

namespace Inventory_Managment_System.Models.Classes
{
    public class Brand
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime createdAt {get ; set ;}
        public DateTime updatedAt {get ; set ;}
    }
}
