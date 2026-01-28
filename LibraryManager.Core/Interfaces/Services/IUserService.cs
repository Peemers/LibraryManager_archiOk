using LibraryManager.Domain.Entities;

namespace LibraryManager.Core.Interfaces.Services;

public interface IUserService : IBaseService<User>
{
  Task<User> GetByEmailAsync(string email);
}