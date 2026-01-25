using LibraryManager.Core.Interfaces.Repositories;
using LibraryManager.Core.Interfaces.Services;
using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Enums;
using System.Linq;

namespace LibraryManager.Core.Services.Data;

public class LivreService(ILivreRepository livreRepository)
  : BaseService<Livre>(livreRepository), ILivreService
{
  public override async Task<IEnumerable<Livre>> GetAllAsync()
  {
    var livres = await base.GetAllAsync();
    return livres.OrderBy(l => l.Nom).ToList();
  }

  public async Task<IEnumerable<Livre>> GetLivreDispoAsync()
  {
    var livres = await base.GetAllAsync();
    return livres.Where(l => l.StatutLivre == LivreStatut.Disponible);
  }
}