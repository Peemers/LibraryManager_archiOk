using LibraryManager.Core.Interfaces.Repositories;
using LibraryManager.Core.Interfaces.Services;
using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Enums;

namespace LibraryManager.Core.Services.Data;

public class BaseService<T>(IBaseRepository<T> baseRepository) : IBaseService<T> where T : class
{
  public virtual Task<IEnumerable<T>> GetAllAsync()
  {
    return baseRepository.GetAllAsync();
  }

  public virtual Task<T?> GetByIdAsync(Guid id)
  {
    return baseRepository.GetByIdAsync(id);
  }

  public virtual Task DeleteAsync(Guid id)
  {
    return baseRepository.DeleteAsync(id);
  }

  public virtual Task<T> UpdateAsync(Guid id, T livre)
  {
    return UpdateAsync(id, livre);
  }

  public virtual Task<T> CreateAsync(T livre)
  {
    return CreateAsync(livre);
  }
}