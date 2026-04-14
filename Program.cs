global using GestionBibliotecaApi.Models;
global using GestionBibliotecaApi.Data;
global using GestionBibliotecaApi.DTOs;

using Microsoft.EntityFrameworkCore;
using GestionBibliotecaApi.Repositories;
using GestionBibliotecaApi.Service;

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

builder.Services.AddDbContext<LibreriaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<LibroService>();
builder.Services.AddScoped<MiembroService>();
builder.Services.AddScoped<PrestamoService>();
builder.Services.AddControllers();

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();