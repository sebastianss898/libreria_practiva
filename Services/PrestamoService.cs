namespace GestionBibliotecaApi.Service;

using System.Linq.Expressions;
using GestionBibliotecaApi.DTOs;
using GestionBibliotecaApi.Models;
using GestionBibliotecaApi.Repositories;

public class PrestamoService
{
    private readonly IRepository<Prestamo> _repo;
    private readonly IRepository<Libro> _libroRepo;
    public PrestamoService(IRepository<Prestamo> repo, IRepository<Libro> libroRepo)
    {
        _repo = repo;
        _libroRepo = libroRepo;
    }

    private PrestamoDto ToDto(Prestamo p) => new PrestamoDto
    {
        Id = p.Id,
        Miembro = p.Miembro?.Nombre ?? "N/A",
        Libro = p.Libro?.Titulo ?? "N/A",
        FechaPrestamo = p.FechaPrestamo,
        FechaDevolucion = p.FechaDevolucion,
    };

    public async Task<List<PrestamoDto>> GetAll()
    {
        var prestamos = await _repo.GetAll();
        return prestamos.Select(ToDto).ToList();
    }

    public async Task<PrestamoDto> GetById(int id)
    {
        var prestamos = await _repo.GetById(id);
        return prestamos is null ? null : ToDto(prestamos);
    }

    public async Task<(bool success, string error, PrestamoDto? dto)> Crear(CrearPrestamoDto dto)
{
    // 🔥 Normalizar fechas a UTC
    dto.FechaPrestamo = DateTime.SpecifyKind(dto.FechaPrestamo, DateTimeKind.Utc);
    dto.FechaDevolucion = DateTime.SpecifyKind(dto.FechaDevolucion, DateTimeKind.Utc);

    if (dto.FechaDevolucion <= dto.FechaPrestamo)
        return (false, "La fecha de salida debe ser mayor a la de entrada", null);

    if (dto.FechaPrestamo <= DateTime.UtcNow)
        return (false, "No puedes reservar en el pasado", null);

    var libro = await _libroRepo.GetById(dto.LibroId);
    if (libro is null)
        return (false, "El libro no existe", null);

    if (!libro.Disponible)
        return (false, "El libro no está disponible", null);

    var prestamoExistente = await _repo.FindAsync(p =>
        p.LibroId == dto.LibroId &&
        p.FechaPrestamo < dto.FechaDevolucion &&
        p.FechaDevolucion > dto.FechaPrestamo);

    if (prestamoExistente is not null)
        return (false, "El libro ya tiene un préstamo en esas fechas", null);

    var prestamo = new Prestamo
    {
        LibroId = dto.LibroId,
        MiembroId = dto.MiembroId,
        FechaPrestamo = dto.FechaPrestamo,
        FechaDevolucion = dto.FechaDevolucion
    };

    await _repo.Add(prestamo);
    return (true, string.Empty, ToDto(prestamo));
}
    public async Task<bool> Eliminar(int id)
    {
        var prestamo = await _repo.GetById(id);
        if (prestamo is null) return false;

        await _repo.Delete(prestamo);
        return true;
    }

    public async Task<PrestamoDto?> Actualizar(int id, ActualizarPrestamoDto dto)
    {
        var prestamo = await _repo.GetById(id);
        if (prestamo is null) return null;

        prestamo.FechaPrestamo = dto.FechaPrestamo;
        prestamo.FechaDevolucion = dto.FechaDevolucion;

        await _repo.SaveChanges();
        return ToDto(prestamo);
    }

    public async Task<List<PrestamoDto>> GetByMiembro(int miembroId)
{
    var prestamos = await _repo.GetAll();
    return prestamos
        .Where(p => p.MiembroId == miembroId)
        .Select(ToDto)
        .ToList();
}
}
