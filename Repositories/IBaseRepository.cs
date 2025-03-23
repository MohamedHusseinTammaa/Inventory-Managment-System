using System.Linq.Expressions;

namespace Inventory_Managment_System.Repositories
{
    public interface IBaseRepository <T> where T :class
    {
        public T getByID(int id);
        Task<IEnumerable<T>> getAllAsync();
        Task<IEnumerable<T>> findAllAsync(Expression<Func<T, bool>> expression, int? take, int? skip);
        T add(T entity);
        Task<T> addAsync(T entity);
        void delete(T entity);
        T update(T entity,int id);
        Task <int> countAllAsync();
        Task<int> countSpecificItems(Expression<Func<T, bool>> expression);
    }
}
