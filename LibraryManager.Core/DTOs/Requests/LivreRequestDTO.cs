using LibraryManager.Domain.Enums;

namespace LibraryManager.Core.DTOs.Requests;

public class LivreRequestDTO
{
  public required string Nom { get; set; }
  public required string Auteur { get; set; }
  public LivreStatut? StatutLivre { get; set; }
}