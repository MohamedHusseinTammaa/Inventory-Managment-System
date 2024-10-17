namespace Inventory_Managment_System.Models.Classes
{
    public class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string contactInfo { get; set; } // multivalue attribute
        public string address { get; set; } //composite attribute

    }
}
