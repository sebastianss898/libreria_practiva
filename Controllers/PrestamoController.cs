namespace GestionBibliotecaApi.Controllers;

using Microsoft.AspNetCore.Mvc;

using GestionBibliotecaApi.DTOs;
using GestionBibliotecaApi.Service;

[ApiController]
[Route("/Prestamos")]

public class PrestamoController : ControllerBase
{
    public readonly PrestamoService _service;

    public PrestamoController(PrestamoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var prestamo = await _service.GetById(id);
        return prestamo is null ? NotFound() : Ok(prestamo);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(CrearPrestamoDto dto)
    {
        var (success, error, prestamo) = await _service.Crear(dto);
        if (!success) return BadRequest(error);
        return Created($"/Habitaciones/{prestamo!.Id}", prestamo);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var eliminado = await _service.Eliminar(id);
        return eliminado ? NoContent() : NotFound();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult>  Actualizar(int id, ActualizarPrestamoDto dto)
    {
        var prestamo = await _service.Actualizar(id, dto);
        return prestamo is null ? NotFound() : Ok(prestamo);
    }
}