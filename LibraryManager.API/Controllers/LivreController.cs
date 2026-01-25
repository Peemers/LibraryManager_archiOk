using LibraryManager.Core.DTOs.Requests;
using LibraryManager.Core.DTOs.Responces;
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

  [HttpPost]
  public async Task<IActionResult> PostLivre(LivreRequestDTO dto)
  {
    var livreId = await _livreService.CreateAsync(dto);

    return CreatedAtAction(
      nameof(GetById),
      new { id = livreId },
      null
    );
  }
  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(Guid id)
  {
    var livre = await _livreService.GetByIdAsync(id);

    if (livre == null)
      return NotFound();

    return Ok(livre);
  }
}



