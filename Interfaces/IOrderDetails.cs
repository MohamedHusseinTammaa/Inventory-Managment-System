using Inventory_Managment_System.Models.Classes;
using Inventory_Managment_System.Services;

namespace Inventory_Managment_System.Interfaces
{
    public interface IOrderDetails
    {
        Task<OrderDetails> AddOrderDetailsAsync(OrderDetails orderDetails);
    }
}
