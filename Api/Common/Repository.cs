using System.Linq.Expressions;
using Api.Common.Interfaces;
using Api.Common.Paginator;
using Microsoft.EntityFrameworkCore;

namespace Api.Common
{
  public class Repository<T>(ApplicationDbContext context) : IRepository<T> where T : class
  {
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<T>> GetAllAsync()
    {
      return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
      return await _context.Set<T>().FindAsync(id);
    }

    public async Task<PaginationResult<T>> GetWhereAsyncWithPaginator(int pageNumber, int pageSize, Expression<Func<T, bool>> predicate)
    {
      var query = _context.Set<T>().AsQueryable().Where(predicate);

      var totalItems = query.Count();

      var data = await query.Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

      return new PaginationResult<T>
        {
          Data = data,
          TotalItems = totalItems
        };
    }

    public async Task<T> GetWhereAsync(Expression<Func<T, bool>> predicate)
    {
      return await _context.Set<T>().Where(predicate).FirstOrDefaultAsync();
    }

    public async Task AddAsync(T entity)
    {
      _context.Set<T>().Add(entity);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
      _context.Entry(entity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
      _context.Set<T>().Remove(entity);
      await _context.SaveChangesAsync();
    }
  }
}