using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using LibraryManager.Infrastructure.DataBase;
using LibraryManager.Core.Interfaces.Repositories;
using LibraryManager.Core.Interfaces.Services;
using LibraryManager.Core.Services.Data; // Vérifie que LivreService est bien ici
using LibraryManager.Infrastructure.Repositories;
using LibraryManager.Infrastructure.Repositories.Configurations;

var builder = WebApplication.CreateBuilder(args);

// 1. Base de données
builder.Services.AddDbContext<LibraryManagerContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

//Injection de dépendances

builder.Services.AddScoped<ILivreRepository, LivreRepository>();
builder.Services.AddScoped<ILivreService, LivreService>();

// 3. Services de base
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

//Pipeline HTTP (Middleware)
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
  app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();