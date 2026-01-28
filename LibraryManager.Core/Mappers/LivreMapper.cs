using LibraryManager.Core.DTOs.Requests;
using LibraryManager.Core.DTOs.Requests.LivreRequest;
using LibraryManager.Core.DTOs.Responces;
using LibraryManager.Core.DTOs.Responces.LivreResponse;
using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Enums;

namespace LibraryManager.Core.Mappers;

public static class LivreMapper
{
  // Sens : API -> SERVICE
  public static Livre ToEntity(this LivreRequestDTO dto)
  {
    return new Livre
    {
      Nom = dto.Nom,
      Auteur = dto.Auteur
    };
  }

  // Sens : SERVICE -> API
  public static LivreResponceDto ToResponseDto(this Livre entity)
  {
    return new LivreResponceDto
    {
      Id = entity.Id,
      Nom = entity.Nom,
      Auteur = entity.Auteur,
    };
  }
}