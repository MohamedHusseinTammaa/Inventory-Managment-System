using System.Linq.Expressions;
using Inventory_Managment_System.Data;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Managment_System.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly InventoryDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(InventoryDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T getByID(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<IEnumerable<T>> getAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> findAllAsync(Expression<Func<T, bool>> expression, int? take, int? skip)
        {
            IQueryable<T> query = _dbSet.Where(expression);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            return await query.ToListAsync();
        }

        public T add(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public async Task<T> addAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public void delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public async Task<int> countAllAsync()
        {
            return await _dbSet.CountAsync();
        }

        public async Task<int> countSpecificItems(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.CountAsync(expression);
        }
    }
}
