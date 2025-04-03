using Inventory_Managment_System.Models.Classes;
using System.Collections.Generic;

namespace Inventory_Managment_System.Interfaces
{
    public interface IOrder 
    {
        public Order GetOrderById(int id);
        public IEnumerable<Order> getOrdersByName(string name);
        public Task<IEnumerable<Order>> GetAllOrders();
        public Task<Order> AddOrderAsync(Order Order);
        public Task<int> CountAllOrders();
        public void UpdateOrder(Order Order);
        public void DeleteOrder(int id);
        public void CalculateTotalAmount(List<OrderDetails> list);
    }
}
