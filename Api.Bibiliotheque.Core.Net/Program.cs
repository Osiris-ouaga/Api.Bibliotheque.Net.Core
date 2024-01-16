using Api.Bibiliotheque.Core.Net.Configuration;
using Api.Bibiliotheque.Core.Net.Interfaces;
using Api.Bibiliotheque.Core.Net.Models;
using Api.Bibiliotheque.Core.Net.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

//Configuration du logger
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

builder.Host.UseSerilog();

//Ajout de l'authentification
builder.Services.AddAuthenticationService();

// Add services to the container.
builder.Services.AddDbContext<BibliothequeContext>(opt => opt.UseInMemoryDatabase("MyDatabase"));

//Dependency injection de nos services métiers
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddControllersService();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGenService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//UseAuthentification avant UseAuthorization (important)
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
