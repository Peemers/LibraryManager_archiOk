namespace LibraryManager.Core.Interfaces.Services;

public interface IBaseService<T> where T : class
{
  Task<IEnumerable<T>> GetAllAsync();
  Task<T?> GetByIdAsync(Guid id);
  
  Task<T> CreateAsync(T entity);
  Task<T> UpdateAsync(T entity);
  Task DeleteAsync(Guid id);
}