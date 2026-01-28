namespace LibraryManager.Core.DTOs.Responces;

public class UserResponceDto
{
  public Guid Id { get; set; }
  public string Email { get; set; }  = string.Empty;
  public string FirstName { get; set; } =  string.Empty;
  public string LastName { get; set; } =  string.Empty;
}