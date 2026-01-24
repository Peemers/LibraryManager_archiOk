using LibraryManager.Domain.Entities;

namespace LibraryManager.Core.Interfaces.Services;

public interface ILivreService : IBaseService<Livre>
{
  Task<IEnumerable<Livre>> GetLivreDispoAsync();
}