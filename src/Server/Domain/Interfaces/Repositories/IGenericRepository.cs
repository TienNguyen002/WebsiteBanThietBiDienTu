using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<T> GetByIdWithInclude(int id, params Expression<Func<T, object>>[] includeProperties);
        Task<IList<T>> GetAll();
        Task<IList<T>> GetAllWithInclude(params Expression<Func<T, object>>[] includeProperties);
        Task Add(T entity);
    }
}
