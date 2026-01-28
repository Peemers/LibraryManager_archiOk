using LibraryManager.Core.Interfaces.Repositories;
using LibraryManager.Core.Interfaces.Services;
using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Enums;
using System.Linq;
using LibraryManager.Core.DTOs.Requests;
using LibraryManager.Core.Mappers;

namespace LibraryManager.Core.Services.Data;

public class LivreService(ILivreRepository livreRepository)
  : BaseService<Livre>(livreRepository), ILivreService
{
  #region GetAllAsync

  public override async Task<IEnumerable<Livre>> GetAllAsync()
  {
    var livres = await base.GetAllAsync();
    return livres.OrderBy(l => l.Nom).ToList();
  }

  #endregion
  
  #region GetLivreDispoAsync

  public async Task<IEnumerable<Livre>> GetLivreDispoAsync()
  {
    var livres = await base.GetAllAsync();
    return livres.Where(l => l.StatutLivre == LivreStatut.Disponible);
  }

  #endregion
  
  #region ChangeStatutAsync

  public async Task<Livre?> ChangeStatutAsync(Guid livreId, LivreStatut nouveauStatut)
  {
    var livre = await base.GetByIdAsync(livreId);

    if (livre == null)
      throw new Exception("Livre introuvable");

    if (livre.StatutLivre == nouveauStatut)
      return livre;

    livre.StatutLivre = nouveauStatut;

    await base.UpdateAsync(livre);

    return livre;
  }

  #endregion
  
  #region CreateFromDtoAsync

  public async Task<Livre> CreateFromDtoAsync(LivreRequestDTO dto)
  {
    if (string.IsNullOrWhiteSpace(dto.Nom) || string.IsNullOrWhiteSpace(dto.Auteur))
      throw new ArgumentException("Données invalides");

    var livres = dto.ToEntity();
    return await this.CreateAsync(livres);
  }

  #endregion
  
  #region CreateAsync

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

  #endregion
  
}