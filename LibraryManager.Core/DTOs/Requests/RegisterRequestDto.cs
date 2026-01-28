namespace LibraryManager.Core.DTOs.Requests;

public class RegisterRequestDto
{
  public Guid Id { get; set; }
  public required string Email { get; set; } = string.Empty;
  public required string PasswordHash { get; set; } =  string.Empty;
}