using Inventory_Managment_System.Models.Classes;

namespace Inventory_Managment_System.Interfaces
{
    public interface ICustomer
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
    }
}
