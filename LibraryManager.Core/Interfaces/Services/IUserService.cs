using LibraryManager.Core.DTOs.Requests.UserRequest;
using LibraryManager.Domain.Entities;

namespace LibraryManager.Core.Interfaces.Services;

public interface IUserService : IBaseService<User>
{
  Task<User?> GetByEmailAsync(string email);
  Task<User?> CreateByDtoAsync(RegisterRequestDto dto);
  Task<User?> UpdateEmailAsync(Guid id, string dtoEmail);
}