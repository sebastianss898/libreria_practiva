namespace GestionBibliotecaApi.Service;

using GestionBibliotecaApi.DTOs;
using GestionBibliotecaApi.Models;
using GestionBibliotecaApi.Repositories;

public class MiembroService
{
    private readonly IRepository<Miembro> _repo;
    public MiembroService(IRepository<Miembro> repo)
    {
        _repo = repo;
    }

    private MiembroDto ToDto(Miembro m) => new MiembroDto
    {
        Id = m.Id,
        Nombre = m.Nombre,
        Email = m.Email,
        FechaRegistro = m.FechaRegistro,
        
    };

    public async Task<List<MiembroDto>> GetAll()
    {
        var miembro = await _repo.GetAll();
        return miembro.Select(ToDto).ToList();
    }

    public async Task<MiembroDto> GetById(int id)
    {
        var miembro = await _repo.GetById(id);
        return miembro is null ? null : ToDto(miembro);
    }

    public async Task<(bool success, string error,MiembroDto? dto)> Crear(CrearMiembroDto dto)
    {
        var miembro = new Miembro
        {
        Nombre = dto.Nombre,
        Email = dto.Email,
        FechaRegistro = dto.FechaRegistro,
        };
        await _repo.Add(miembro);
        return(true, string.Empty, ToDto(miembro));
    }

    public async Task<bool> Eliminar(int id)
    {
        var miembro = await _repo.GetById(id);
        if(miembro is null) return false;

        await _repo.Delete(miembro);
        return true;
    }

    public async Task<MiembroDto?> Actualizar(int id, ActualizarMiembroDto dto)
    {
        var miembro = await _repo.GetById(id);
        if(miembro is null) return null;

        miembro.Nombre = dto.Nombre;
        miembro.Email = dto.Email;
        miembro.FechaRegistro = dto.FechaRegistro;

        await _repo.SaveChanges();
        return ToDto(miembro);
    }
}
