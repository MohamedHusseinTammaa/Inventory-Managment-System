using Inventory_Managment_System.Interfaces;
using Inventory_Managment_System.Models.Classes;
using Inventory_Managment_System.UnitOfWork;
using System.Collections;

namespace Inventory_Managment_System.Services
{
    public class CustomerServices : ICustomer
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _unitOfWork.Repository<Customer>().getAllAsync();
        } 
    }
}
