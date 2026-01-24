using LibraryManager.Core.Interfaces.Repositories;
using LibraryManager.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Repositories.Configurations;

public class BaseRepository<T>(LibraryManagerContext _context) : IBaseRepository<T> where T : class
{
  protected DbSet<T> _entities => _context.Set<T>();

  public async Task<T> AddAsync(T entity)
  {
    await _entities.AddAsync(entity);
    await _context.SaveChangesAsync();
    return entity;
  }

  public async Task DeleteAsync(Guid id)
  {
    var entity = await _entities.FindAsync(id);
    if (entity != null)
    {
      _entities.Remove(entity);
      await _context.SaveChangesAsync();
    }
  }


  public async Task<IEnumerable<T>> GetAllAsync()
  {
    return await _entities.ToListAsync();
  }

  public async Task<T?> GetByIdAsync(Guid id)
  {
    return await _entities.FindAsync(id);
  }

  public async Task UpdateAsync(T entity)
  {
    _entities.Update(entity);
    await _context.SaveChangesAsync();
  }

  public async Task<bool> ExistsAsync(Guid id)
  {
    return await Task.FromResult(_entities.Find(id) != null);
  }
}