namespace Inventory_Managment_System.Models.Classes
{
    public class Supplier
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }//multivalue attribute
        public string address { get; set; }// composite attribute

    }
}
