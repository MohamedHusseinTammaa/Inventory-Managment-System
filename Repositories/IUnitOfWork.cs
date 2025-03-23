using System;
using System.Threading.Tasks;
using Inventory_Managment_System.Repositories;

namespace Inventory_Managment_System.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        // Get repository of type T
        IBaseRepository<T> Repository<T>() where T : class;
        
        // Save changes
        int Complete();
        
        // Save changes asynchronously
        Task<int> CompleteAsync();
    }
}
