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

  public override async Task<Livre> CreateAsync(Livre livre)
  {
    if (string.IsNullOrWhiteSpace(livre.Nom) || string.IsNullOrWhiteSpace(livre.Auteur))
    {
      throw new ArgumentException("Le nom et l'auteur sont obligatoires pour référencer un livre.");
    }

    livre.Id = Guid.NewGuid();
    livre.StatutLivre = LivreStatut.Disponible;

    return await base.CreateAsync(livre);
  }
}