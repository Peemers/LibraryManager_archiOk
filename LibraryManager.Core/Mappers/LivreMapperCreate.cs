using LibraryManager.Core.DTOs.Requests;
using LibraryManager.Core.DTOs.Responces;
using LibraryManager.Domain.Entities;

namespace LibraryManager.Core.Mappers;

public static class LivreMapperCreate
{
  public static LivreRequestDTO ToDto(this Livre livre)
  {
    return new LivreRequestDTO()
    {
      Nom = livre.Nom,
      Auteur = livre.Auteur,
      StatutLivre = livre.StatutLivre,
    };
  }
}