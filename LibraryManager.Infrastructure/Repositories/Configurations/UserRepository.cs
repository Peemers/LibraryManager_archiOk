using LibraryManager.Core.Interfaces.Repositories;
using LibraryManager.Domain.Entities;
using LibraryManager.Infrastructure.DataBase;

namespace LibraryManager.Infrastructure.Repositories.Configurations;

public class UserRepository (LibraryManagerContext _context) : BaseRepository<User>(_context), IUserRepository
{
  
}