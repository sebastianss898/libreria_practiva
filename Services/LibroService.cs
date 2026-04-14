namespace GestionBibliotecaApi.Service;

using GestionBibliotecaApi.DTOs;
using GestionBibliotecaApi.Models;
using GestionBibliotecaApi.Repositories;

public class LibroService
{
    private readonly IRepository<Libro> _repo;
    public LibroService(IRepository<Libro> repo)
    {
        _repo = repo;
    }

    private LibroDto ToDto(Libro l) => new LibroDto
    {
        Id = l.Id,
        Titulo = l.Titulo,
        Autor = l.Autor,
        Año = l.Año,
        Disponible = l.Disponible
    };

    public async Task<List<LibroDto>> GetAll()
    {
        var Libros = await _repo.GetAll();
        return Libros.Select(ToDto).ToList();
    }

    public async Task<LibroDto> GetById(int id)
    {
        var libro = await _repo.GetById(id);
        return libro is null ? null : ToDto(libro);
    }

    public async Task<(bool success, string error, LibroDto? dto)> Crear(CrearLibroDto dto)
    {

        if (string.IsNullOrEmpty(dto.Titulo))
            return (false, "El título es requerido", null);


        var libro = new Libro
        {
            Titulo = dto.Titulo,
            Autor = dto.Autor,
            Año = dto.Año,
            Disponible = dto.Disponible
        };
        await _repo.Add(libro);
        return (true, string.Empty, ToDto(libro));
    }

    public async Task<bool> Eliminar(int id)
    {
        var libro = await _repo.GetById(id);
        if (libro is null) return false;

        await _repo.Delete(libro);
        return true;
    }

    public async Task<LibroDto?> Actualizar(int id, ActualizarLibroDto dto)
    {
        var libro = await _repo.GetById(id);
        if (libro is null) return null;

        libro.Disponible = dto.Disponible;

        await _repo.SaveChanges();
        return ToDto(libro);
    }

    public async Task<List<LibroDto>> GetDisponibles()
    {   
        var libros = await _repo.GetAll();
        return libros.Where(l => l.Disponible).Select(ToDto).ToList();
    }
}
