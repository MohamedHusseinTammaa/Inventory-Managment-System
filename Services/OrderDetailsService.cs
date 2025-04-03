using Inventory_Managment_System.Interfaces;
using Inventory_Managment_System.Models.Classes;
using Inventory_Managment_System.UnitOfWork;

namespace Inventory_Managment_System.Services
{
    public class OrderDetailsService : IOrderDetails
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderDetailsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderDetails> AddOrderDetailsAsync(OrderDetails orderDetails)
        {
            await _unitOfWork.Repository<OrderDetails>().addAsync(orderDetails);
            await _unitOfWork.CompleteAsync();
            return orderDetails;
        }

        
    }
}