using System.Linq.Expressions;
using Inventory_Managment_System.Data;
using Inventory_Managment_System.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Managment_System.Repositories
{
    /// <summary>
    /// Generic repository for performing CRUD operations on entities.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : class 
    {
        protected readonly InventoryDbContext _context;
        protected readonly DbSet<T> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public BaseRepository(InventoryDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        /// <summary>
        /// Gets an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>The entity with the specified identifier.</returns>
        public T getByID(int id)
        {
            return _dbSet.Find(id);
        }


        public IEnumerable<T> getByName(string name)
        {
            // Constraint to ensure T has a name property
            if (typeof(T).GetProperty("name") != null )
            {
                if(typeof(T).GetProperty("isDeleted") != null)
                    return _dbSet
                        .Where(p => EF.Property<string>(p, "name").ToLower().Contains(name.ToLower()) && EF.Property<bool>(p, "isDeleted") == false)
                        .ToList();
                else 
                    return _dbSet
                    .Where(p => EF.Property<string>(p, "name").ToLower().Contains(name.ToLower()))
                    .ToList();
            }

            throw new InvalidOperationException($"{typeof(T).Name} does not have a Name property.");
        }
        /// <summary>
        /// Gets all entities asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the list of entities.</returns>
        public async Task<IEnumerable<T>> getAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        /// <summary>
        /// Finds entities that match the specified expression with optional pagination.
        /// </summary>
        /// <param name="expression">The expression to filter entities.</param>
        /// <param name="take">The number of entities to take.</param>
        /// <param name="skip">The number of entities to skip.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the list of matching entities.</returns>
        public async Task<IEnumerable<T>> findAllAsync(Expression<Func<T, bool>> expression, int? take, int? skip)
        {
            IQueryable<T> query = _dbSet.Where(expression);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            return await query.ToListAsync();
        }

        /// <summary>
        /// Adds a new entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        public T add(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        /// <summary>
        /// Adds a new entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the added entity.</returns>
        public async Task<T> addAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public void delete(int id)
        {
            
            var entity = _dbSet.Find(id);
            if (entity == null)
                throw new KeyNotFoundException($"Entity with ID {id} not found.");
            _dbSet.Remove(entity);
        }

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        public T update(T entity, int id)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var existing = _dbSet.Find(id);
            if (existing == null)
                throw new KeyNotFoundException($"Entity with ID {id} not found.");

            _context.Entry(existing).CurrentValues.SetValues(entity);
            return existing;
        }


        /// <summary>
        /// Counts all entities asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the count of entities.</returns>
        public int countAll()
        {
            return _dbSet.Count();
        }

        /// <summary>
        /// Counts entities that match the specified expression asynchronously.
        /// </summary>
        /// <param name="expression">The expression to filter entities.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the count of matching entities.</returns>
        public async Task<int> countSpecificItems(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.CountAsync(expression);
        }
    }
}
