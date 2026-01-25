using LibraryManager.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class LivreController : ControllerBase
{
  private ILivreRepository _livreRepository;
}