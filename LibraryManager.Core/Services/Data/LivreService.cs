using LibraryManager.Core.Interfaces.Repositories;
using LibraryManager.Core.Interfaces.Services;
using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Enums;

namespace LibraryManager.Core.Services.Data;

public class LivreService(ILivreRepository livreRepository) 
  : BaseService<Livre>(livreRepository), ILivreService
{
  //todo override BaseService
}