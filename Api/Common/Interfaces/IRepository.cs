using System.Linq.Expressions;
using Api.Common.Paginator;

namespace Api.Common.Interfaces {
  public interface IRepository<T>
  {
    
    Task<IEnumerable<T>> GetAllAsync();
    
    Task<T> GetByIdAsync(int id);

    Task AddAsync(T entity);

    Task<T> GetWhereAsync(Expression<Func<T, bool>> predicate);

    Task<PaginationResult<T>> GetWhereAsyncWithPaginator(int pageNumber, int pageSize, Expression<Func<T, bool>> predicate);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);
  }
}