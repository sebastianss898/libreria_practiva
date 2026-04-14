namespace GestionBibliotecaApi.Data;

using GestionBibliotecaApi.Models;
using Microsoft.EntityFrameworkCore;

public class LibreriaContext : DbContext
{
    public LibreriaContext(DbContextOptions<LibreriaContext> options): base(options) { }
    public DbSet<Libro> Libros { get; set; }
    public DbSet<Miembro> Miembros { get; set; }
    public DbSet<Prestamo> Prestamos { get; set; }
}