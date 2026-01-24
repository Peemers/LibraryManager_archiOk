namespace LibraryManager.Core.Interfaces.Services;

public interface IBaseService<T> where T : class
{
  Task<IEnumerable<T>> GetAll();
  Task<T?> GetById(Guid id);
  
  Task<T> Create(T livre);
  Task<T> Update(Guid id, T livre);
  Task Delete(Guid id);
}