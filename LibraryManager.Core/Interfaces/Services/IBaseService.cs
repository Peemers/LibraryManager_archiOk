namespace LibraryManager.Core.Interfaces.Services;

public interface IBaseService<T> where T : class
{
  Task<IEnumerable<T>> GetAllAsync();
  Task<T?> GetByIdAsync(Guid id);
  
  Task<T> CreateAsync(T livre);
  Task<T> UpdateAsync(Guid id, T livre);
  Task DeleteAsync(Guid id);
}