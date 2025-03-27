using Inventory_Managment_System.Interfaces;
using Inventory_Managment_System.Models.Classes;
using System;
using System.Collections.Generic;
using Inventory_Managment_System.Data;
using Inventory_Managment_System.UnitOfWork;

namespace Inventory_Managment_System.Services
{
    public class SupplierServices : ISupplier
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Supplier>> getAllSuppliers()
        {
            return await _unitOfWork.Repository<Supplier>().getAllAsync();
        }
        public  async Task<int> CountAllSuppliers()
        {
            return await _unitOfWork.Repository<Supplier>().countAllAsync();
        }
    }
}
