using Inventory_Managment_System.Models.Classes;
using System.Collections.Generic;

namespace Inventory_Managment_System.Interfaces
{
    public interface Iorder 
    {
        public order GetOrderById(int id);
        public IEnumerable<order> getOrdersByName(string name);
        public Task<IEnumerable<order>> GetAllOrders();
        public Task<order> AddOrderAsync(order order);
        public Task<int> CountAllOrders();
        public void UpdateOrder(order order);
        public void DeleteOrder(int id);
        public void CalculateTotalAmount(List<orderDetails> list);
    }
}
