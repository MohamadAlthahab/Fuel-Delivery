using System.Collections.Generic;
using System.Linq.Expressions;

namespace Fuel_Delivery.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAll(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            List<string> includes = null);

        Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null);
        void add(T enAsynctity);
        Task Insert(T entity);
        Task Remove(int id);
        void Update(T entity);
    }
}
