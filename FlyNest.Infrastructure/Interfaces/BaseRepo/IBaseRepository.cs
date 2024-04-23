using System.Linq.Expressions;

namespace FlyNest.Infrastructure.Interfaces.BaseRepo;

public interface IBaseRepository<T> where T : class
{
    IQueryable<T> GetAll();

    Task<List<T>> GetAllAsync();

    IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);

    Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);

    T FirstOrDefault(long? id);

    Task<T> FirstOrDefaultAsync(long? id);

    T FirstOrDefault(long? id, params Expression<Func<T, object>>[] includeProperties);

    Task<T> FirstOrDefaultAsync(long? id, params Expression<Func<T, object>>[] includeProperties);

    #region CURD Operation
    Task InsertAsync(T entity);

    Task InsertRangeAsync(List<T> entities);

    Task UpdateAsync(T entity);
    Task UpdateAsync(object id, T entity);

    Task UpdateRangeAsync(List<T> entities);

    Task<T> DeleteAsync(object id);

    Task DeleteRangeAsync(List<T> entities);

    Task DeleteAsync(T entity);
    #endregion

    void Attach(T entity);

    void Detach(T entity);
}
