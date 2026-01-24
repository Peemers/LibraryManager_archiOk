using LibraryManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.DataBase;

public class LibraryManagerContext : DbContext
{
  public LibraryManagerContext(DbContextOptions options) : base(options)
  {
    
  }

  protected LibraryManagerContext()
  {
    
  }
  
  public DbSet<Livre> Livres { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryManagerContext).Assembly);
  }
}