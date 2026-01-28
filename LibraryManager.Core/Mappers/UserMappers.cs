using LibraryManager.Core.DTOs.Requests;
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
}