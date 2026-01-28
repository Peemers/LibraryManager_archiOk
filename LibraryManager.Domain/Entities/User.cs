

using LibraryManager.Domain.Enums;

namespace LibraryManager.Domain.Entities;


public class User
{
  public Guid Id { get; set; }
  public string? Email { get; set; }
  public string? PasswordHash { get; set; }
  public UsersRoles Role { get; set; } = UsersRoles.User;
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
}