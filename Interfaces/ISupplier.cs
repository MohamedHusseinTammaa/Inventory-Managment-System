namespace Inventory_Managment_System.Interfaces
{
    public interface ISupplier
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }//multivalue attribute
        public string address { get; set; }// composite attribute

    }
}
