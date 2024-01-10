using System.Linq.Expressions;

namespace Application.Interfaces.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> expression);
    Task<T> AddAsync(T entity);
    void UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
