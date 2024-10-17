namespace Inventory_Managment_System.Models.Classes
{
    public class purchase
    {
        public int id { get; set; }
        public double totalCost { get; set; }
        public int supplierId { get; set; }
        public DateTime purchaseDate { get; set; }
    }
}
