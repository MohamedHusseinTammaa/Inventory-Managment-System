using Inventory_Managment_System.Interfaces;
using Inventory_Managment_System.Models.Classes;
using System;
using System.Collections.Generic;
using Inventory_Managment_System.Data;

namespace Inventory_Managment_System.Models.Services
{
	public class SupplierServices : ISupplier
	{
		private readonly InventoryDbContext _context;

		public SupplierServices(InventoryDbContext context)
		{
			_context = context;
		}
		public List<Supplier> getAllSuppliers()
		{
			var list = _context.suppliers.ToList();
			return list;
		}
	}
}
