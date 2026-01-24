using Microsoft.EntityFrameworkCore;
//using Scalar.AspNetCore;
using System.Text.Json;
using LibraryManager.Infrastructure.DataBase;
using LibraryManager.Core.Interfaces.Repositories;
using LibraryManager.Core.Interfaces.Services;
//using LibraryManager.Core.Interfaces.Services.Auth;
//using LibraryManager.Core.Interfaces.Services.Tools;
//using LibraryManager.Core.Services.Auth;
//using LibraryManager.Core.Services.Data;
//using LibraryManager.Core.Services.Tools;
//using LibraryManager.Infrastructure.Database;
using LibraryManager.Infrastructure.Repositories;
using LibraryManager.Infrastructure.Repositories.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Ajout de la connectionString via l'injection de dépendance
// => L'instance de TodoList sera fournie dans le constructeur de la classe qui a
// besoin de TodoListContext avec la configuration du provider + connectionString
builder.Services.AddDbContext<LibraryManagerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Gestion des cors
//builder.Services.AddCors(options =>
//{
    // Configuration des CORS

    // Pour le développement uniquement
    //options.AddDefaultPolicy(policy => 
    //    policy
    //        .AllowAnyOrigin()
    //        .AllowAnyHeader()
    //        .AllowAnyMethod());

    //options.AddDefaultPolicy(policy =>
    //    policy
    //        .WithOrigins(
    //            "http://localhost:4200", // Angular
    //            "http://localhost:3000", // React
    //            "http://localhost:5500" // Javascript (LiveService
    //        )
    //        .AllowAnyHeader()
    //        .AllowAnyMethod());

    // Avec une configuration dans le appsettings

    // var allowedOrigins = builder.Configuration
    //     .GetSection("Cors:AllowedOrigins")
    //     .Get<string[]>() ?? throw new InvalidOperationException("Cors not configured.");

//     options.AddDefaultPolicy(policy =>
//         policy
//             .WithOrigins(allowedOrigins)
//             .AllowAnyHeader()
//             .AllowAnyMethod()
//     );
// });

// Injection de dépendance
builder.Services.AddScoped<ILivreRepository, LivreRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<ITodoService, TodoService>();
//builder.Services.AddScoped<IAuthService, AuthService>();
//builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();


builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}


app.UseHttpsRedirection();

//app.UseCors(); // Permet d'utiliser les CORS

app.UseAuthorization();

app.MapControllers();

app.Run();