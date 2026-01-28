using LibraryManager.Core.DTOs.Requests;
using LibraryManager.Core.Interfaces.Repositories;
using LibraryManager.Core.Interfaces.Services;
using LibraryManager.Domain.Entities;

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

  public Task<User> CreateByDtoAsync(RegisterRequestDto user)
  {
    if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.PasswordHash))
    {
      throw new ArgumentException("un mail et un mdp sont nécéssaire pour creer un user");
    }

    user.Id = Guid.NewGuid();
    return base.CreateAsync(user);
  }
  
  
}