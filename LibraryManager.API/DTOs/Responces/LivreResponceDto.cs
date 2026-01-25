namespace LibraryManager.API.DTOs.Responces;

public class LivreResponceDto
{
  public Guid Id { get; set; }
  public required string Nom { get; set; } 
  public required string Auteur { get; set; }
}