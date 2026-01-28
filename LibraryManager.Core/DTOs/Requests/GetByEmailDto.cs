namespace LibraryManager.Core.DTOs.Requests;

public class GetByEmailDto
{
  public Guid Id { get; set; }
  public string Email { get; set; }
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
}