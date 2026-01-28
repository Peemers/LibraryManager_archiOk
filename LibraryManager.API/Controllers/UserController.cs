using LibraryManager.Core.DTOs.Responces;
using LibraryManager.Core.Interfaces.Services;
using LibraryManager.Core.Mappers;
using Microsoft.AspNetCore.Mvc;


namespace LibraryManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
  private IUserService? _userService;

  public UserController(IUserService userService)
  {
    _userService = userService;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<UserResponceDto>>> GetUsers()
  {
    var users = await _userService.GetAllAsync();
    var dtoRetour = users.Select(u => u.ToResponseDto()).ToList();
    return Ok(dtoRetour);
  }
}