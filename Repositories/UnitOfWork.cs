using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inventory_Managment_System.Data;
using Inventory_Managment_System.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Managment_System.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventoryDbContext _context;
        private readonly Dictionary<Type, object> _repositories;
        private bool _disposed;

        public UnitOfWork(InventoryDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IBaseRepository<T> Repository<T>() where T : class
        {
            var type = typeof(T);

            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new BaseRepository<T>(_context);
            }

            return (IBaseRepository<T>)_repositories[type];
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }
}
