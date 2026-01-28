using LibraryManager.Core.Interfaces.Repositories;
using LibraryManager.Core.Interfaces.Services;
using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Enums;

namespace LibraryManager.Core.Services.Data;

public class BaseService<T>(IBaseRepository<T> baseRepository) : IBaseService<T> where T : class
{
  public virtual async Task<IEnumerable<T>> GetAllAsync()
  {
    return await baseRepository.GetAllAsync();
  }

  public virtual async Task<T?> GetByIdAsync(Guid id)
  {
    return await baseRepository.GetByIdAsync(id);
  }

  public virtual async Task DeleteAsync(Guid id)
  {
    var livres = await baseRepository.GetByIdAsync(id) ?? throw new DirectoryNotFoundException("livre not found");

    await baseRepository.DeleteAsync(id);
  }


  public virtual async Task<T> UpdateAsync(T livre)
  {
    return await UpdateAsync(livre);
  }

  public virtual async Task<T> CreateAsync(T livre)
  {
    return await CreateAsync(livre);
  }
}