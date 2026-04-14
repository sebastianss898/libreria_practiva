namespace GestionBibliotecaApi.Controllers;

using Microsoft.AspNetCore.Mvc;

using GestionBibliotecaApi.DTOs;
using GestionBibliotecaApi.Service;

[ApiController]
[Route("/miembros")]

public class MiembroController : ControllerBase
{
    public readonly MiembroService _service;
    public readonly PrestamoService _prestamoService; // 👈

    public MiembroController(MiembroService service, PrestamoService prestamoService)
    {
        _service = service;
        _prestamoService = prestamoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var miembro = await _service.GetById(id);
        return miembro is null ? NotFound() : Ok(miembro);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(CrearMiembroDto dto)
    {
        var (success, error, miembro) = await _service.Crear(dto);
        if (!success) return BadRequest(error);
        return Created($"/miembros/{miembro!.Id}", miembro);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var eliminado = await _service.Eliminar(id);
        return eliminado ? NoContent() : NotFound();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, ActualizarMiembroDto dto)
    {
        var miembro = await _service.Actualizar(id, dto);
        return miembro is null ? NotFound() : Ok(miembro);
    }

    [HttpGet("{id}/prestamos")]
    public async Task<IActionResult> GetPrestamos(int id) =>
        Ok(await _prestamoService.GetByMiembro(id));
}