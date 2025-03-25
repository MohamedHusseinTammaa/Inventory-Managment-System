using Inventory_Managment_System.Interfaces;
using System.Linq.Expressions;

namespace Inventory_Managment_System.Repositories
{
    public interface IBaseRepository <T> where T :class 
    {
        public T getByID(int id);
        public IEnumerable<T> getByName(string name);
        Task<IEnumerable<T>> getAllAsync();
        Task<IEnumerable<T>> findAllAsync(Expression<Func<T, bool>> expression, int? take, int? skip);
        T add(T entity);
        Task<T> addAsync(T entity);
        void delete(int id);
        T update(T entity,int id);
        int countAll();
        Task<int> countSpecificItems(Expression<Func<T, bool>> expression);
    }
}
