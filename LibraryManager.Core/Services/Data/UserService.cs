using LibraryManager.Core.DTOs.Requests;
using LibraryManager.Core.DTOs.Requests.UserRequest;
using LibraryManager.Core.Interfaces.Repositories;
using LibraryManager.Core.Interfaces.Services;
using LibraryManager.Core.Mappers;
using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Enums;

namespace LibraryManager.Core.Services.Data;

public class UserService(IUserRepository userRepository) : BaseService<User>(userRepository), IUserService
{
  public async Task<User?> GetByEmailAsync(string email)
  {
    var users = await base.GetAllAsync();
    return users
      .Where(u => u.Email == email)
      .OrderBy(u => u.LastName)
      .FirstOrDefault();
  }

  public override async Task<IEnumerable<User>> GetAllAsync()
  {
    var users = await base.GetAllAsync();
    return users
      .OrderBy(u => u.LastName);
  }

  public Task<User> CreateByDtoAsync(RegisterRequestDto dto)
  {
    if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.PasswordHash))
    {
      throw new ArgumentException("un mail et un mdp sont nécéssaire pour creer un user");
    }

    var usersEntity = dto.ToEntity();
    usersEntity.Id = Guid.NewGuid();
    return base.CreateAsync(usersEntity);
  }

  public async Task<User> ChangeRoleAsync(Guid userId, UsersRoles role)
  {
    var users = await base.GetByIdAsync(userId);
    if (role == UsersRoles.Admin)
    {
      if (users == null)
      {
        throw new Exception("User introuvable");
      }

      if (users.Role == role)
      {
        throw new Exception("User deja avec ce rôle");
      }
      users.Role = role;
    }
    return users;
  }
}