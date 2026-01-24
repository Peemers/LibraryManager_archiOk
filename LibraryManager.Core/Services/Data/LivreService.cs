using LibraryManager.Core.Interfaces.Repositories;
using LibraryManager.Core.Interfaces.Services;
using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Enums;

namespace LibraryManager.Core.Services.Data;

public class LivreService(ILivreRepository livreRepository) : ILivreService
{
  public async Task<Livre> CreateAsync(Livre livre)
  {
    if (livre.Auteur == null || livre.Nom == null)
    {
      throw new ArgumentException("Auteur ET Nom du livre requis");
    }
    //création du livre

    livre.StatutLivre = LivreStatut.Disponible;
    livre.Id = Guid.NewGuid();

    //appel du repo

    var livreCree = await livreRepository.AddAsync(livre);

    return livreCree;
  }

  public async Task<Livre> UpdateAsync(Guid id, Livre livre)
  {
    await livreRepository.UpdateAsync(livre);
    return livre;
  }

  public async Task DeleteAsync(Guid id)
  {
    var existingLivre = await livreRepository.ExistsAsync(id);
    if (!existingLivre) throw new KeyNotFoundException($"Livre {id} not found");
    await livreRepository.DeleteAsync(id);
  }

  public async Task<IEnumerable<Livre>> GetLivreDispoAsync()
  {
    var tousLesLivres = await livreRepository.GetAllAsync();

    //filtrage LINQ
    var disponibles = tousLesLivres.Where(l => l.StatutLivre == LivreStatut.Disponible);

    return disponibles;
  }

  public async Task<IEnumerable<Livre>> GetAllAsync()
  {
    return await livreRepository.GetAllAsync();
  }

  public async Task<Livre?> GetByIdAsync(Guid id)
  {
    return await livreRepository.GetByIdAsync(id);
  }
}