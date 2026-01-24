namespace LibraryManager.Core.Interfaces.Repositories;

public interface IBaseRepository<T> where T : class
{
  //Ici on fait le contrat pour le crud de base
  
  Task<IEnumerable<T>> GetAllAsync();
  Task<T?> GetByIdAsync(Guid id);
  Task<T> AddAsync(T entity);
  Task UpdateAsync(T entity);
  Task DeleteAsync(Guid id);
  
  Task<bool> ExistsAsync(Guid id);
}