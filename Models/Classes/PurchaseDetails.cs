namespace Inventory_Managment_System.Models.Classes
{
    public class PurchaseDetails
    {
        public int id {  get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int purchaseId { get; set; }
        public int productId { get; set; }

    }
}
