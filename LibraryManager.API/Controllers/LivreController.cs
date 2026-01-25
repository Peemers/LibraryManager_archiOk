using LibraryManager.API.DTOs.Responces;
using LibraryManager.Core.Interfaces.Repositories;
using LibraryManager.Core.Interfaces.Services;
using LibraryManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class LivreController : ControllerBase
{
  private ILivreService? _livreService;

  public LivreController(ILivreService livreService)
  {
    _livreService = livreService;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<LivreResponceDto>>> GetLivres()
  {
    var livres = await _livreService.GetAllAsync();
    return Ok(livres);
  }
}



