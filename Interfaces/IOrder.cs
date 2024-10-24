using Inventory_Managment_System.Models.Classes;

namespace Inventory_Managment_System.Interfaces
{
    public interface Iorder
    {

        public IEnumerable<order> GetAllOrders();
        public order GetOrderById(int id);
        public void AddOrder(order order);
        public void UpdateOrder(order order);
        public void DeleteOrder(int id);
        public void CalculateTotalAmount(List<orderDetails> list);
    }
}
