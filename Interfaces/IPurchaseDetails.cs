namespace Inventory_Managment_System.Interfaces
{
    public interface IPurchaseDetails
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int purchaseId { get; set; }
        public int productId { get; set; }

    }
}
