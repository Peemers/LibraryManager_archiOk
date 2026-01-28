using LibraryManager.Core.DTOs.Requests;
using LibraryManager.Core.DTOs.Responces;
using LibraryManager.Domain.Entities;

namespace LibraryManager.Core.Mappers;

public static class UserMappers
{
  public static User ToEntity(this RegisterRequestDto dto)
  {
    return new User
    {
      Email = dto.Email,
      PasswordHash = dto.PasswordHash,
    };
  }

  public static UserResponceDto ToResponseDto(this User dto)
  {
    return new UserResponceDto
    {
      Id = dto.Id,
      Email = dto.Email,
      FirstName = dto.FirstName,
      LastName = dto.LastName,
    };
  }
}