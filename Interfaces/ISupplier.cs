using Inventory_Managment_System.Models.Classes;

namespace Inventory_Managment_System.Interfaces
{
    public interface ISupplier
    {
        public Task<IEnumerable<Supplier>> getAllSuppliers();
        public Task<int> CountAllSuppliers();

    }
}
