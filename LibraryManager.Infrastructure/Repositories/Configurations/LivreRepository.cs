using LibraryManager.Core.Interfaces.Repositories;
using LibraryManager.Domain.Entities;
using LibraryManager.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Repositories.Configurations;

public class LivreRepository(LibraryManagerContext _context) : BaseRepository<Livre>(_context), ILivreRepository
{
  
}