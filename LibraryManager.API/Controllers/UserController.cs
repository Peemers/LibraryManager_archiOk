using LibraryManager.Core.DTOs.Requests.UserRequest;
using LibraryManager.Core.DTOs.Responces;
using LibraryManager.Core.DTOs.Responces.UserResponse;
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
  
  [HttpGet("email/{email}")]
  public async Task<ActionResult<UserResponceDto>> GetByEmail(string email)
  {
    var user = await _userService.GetByEmailAsync(email);
    if (user == null)
      return NotFound();

    return Ok(user.ToResponseDto());
  }
  [HttpPost]
  public async Task<ActionResult<UserResponceDto>> CreateUser([FromBody] RegisterRequestDto dto)
  //frombody : 
  {
    try
    {
      var user = await _userService.CreateByDtoAsync(dto);
      return CreatedAtAction(
        nameof(GetByEmail), 
        new { email = user.Email }, 
        user.ToResponseDto()
      );
    }
    catch (ArgumentException alerte)
    {
      return BadRequest(alerte.Message);
    }
  }
  [HttpPut("{id}/email")]
  public async Task<ActionResult<UserResponceDto>> UpdateEmail(Guid id, [FromBody] UpdateEmailDto? dto)
  {
    if (dto == null || string.IsNullOrWhiteSpace(dto.Email))
      return BadRequest("L'email ne peut pas être vide.");

    var user = await _userService.UpdateEmailAsync(id, dto.Email);
    return Ok(user.ToResponseDto());
  }
}