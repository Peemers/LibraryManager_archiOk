using LibraryManager.Domain.Enums;

namespace LibraryManager.Domain.Entities;

public class Livre
{
  public Guid Id { get; set; }
  public string? Nom { get; set; }
  public string? Auteur { get; set; }
  public int NbPages { get; set; }
  public DateTime DateDeSortie { get; set; }
  public LivreStatut? StatutLivre { get; set; }
}